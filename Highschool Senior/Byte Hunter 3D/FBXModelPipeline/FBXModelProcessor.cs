using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

// TODO: replace these with the processor input and output types.
using TInput = System.String;
using TOutput = System.String;

namespace FBXModelPipeline
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to content data, converting an object of
    /// type TInput to TOutput. The input and output types may be the same if
    /// the processor wishes to alter data without changing its type.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentProcessor attribute to specify the correct
    /// display name for this processor.
    /// </summary>
    [ContentProcessor(DisplayName = "FBXModelPipeline.ContentProcessor1")]
    public class FBXModelProcessor : ContentProcessor<NodeContent,
                                                         FBXModelContent>
    {
        #region Fields

        ContentProcessorContext context;
        FBXModelContent outputModel;

        // A single material may be reused on more than one piece of geometry.
        // This dictionary keeps track of materials we have already converted,
        // to make sure we only bother processing each of them once.
        Dictionary<MaterialContent, MaterialContent> processedMaterials =
                            new Dictionary<MaterialContent, MaterialContent>();

        #endregion


        /// <summary>
        /// Converts incoming graphics data into our custom model format.
        /// </summary>
        public override FBXModelContent Process(NodeContent input,
                                                   ContentProcessorContext context)
        {
            this.context = context;

            outputModel = new FBXModelContent();

            ProcessNode(input);

            return outputModel;
        }


        /// <summary>
        /// Recursively processes a node from the input data tree.
        /// </summary>
        void ProcessNode(NodeContent node)
        {
            // Meshes can contain internal hierarchy (nested tranforms, joints, bones,
            // etc), but this sample isn't going to bother storing any of that data.
            // Instead we will just bake any node transforms into the geometry, after
            // which we can reset them to identity and forget all about them.
            MeshHelper.TransformScene(node, node.Transform);
            
            node.Transform = Matrix.Identity;

            // Is this node in fact a mesh?
            MeshContent mesh = node as MeshContent;

            if (mesh != null)
            {
                // Reorder vertex and index data so triangles will render in
                // an order that makes efficient use of the GPU vertex cache.
                MeshHelper.OptimizeForCache(mesh);

                // Process all the geometry in the mesh.
                foreach (GeometryContent geometry in mesh.Geometry)
                {
                    ProcessGeometry(geometry);
                }
            }

            // Recurse over any child nodes.
            foreach (NodeContent child in node.Children)
            {
                ProcessNode(child);
            }
        }


        /// <summary>
        /// Converts a single piece of input geometry into our custom format.
        /// </summary>
        void ProcessGeometry(GeometryContent geometry)
        {
            int triangleCount = geometry.Indices.Count / 3;
            int vertexCount = geometry.Vertices.VertexCount;

            // Flatten the flexible input vertex channel data into
            // a simple GPU style vertex buffer byte array.
            VertexBufferContent vertexBufferContent = geometry.Vertices.CreateVertexBuffer();

            // Convert the input material.
            MaterialContent material = ProcessMaterial(geometry.Material);

            // Add the new piece of geometry to our output model.
            outputModel.AddModelPart(triangleCount, vertexCount,
                                     vertexBufferContent, geometry.Indices, material);
        }


        /// <summary>
        /// Converts an input material by chaining to the built-in MaterialProcessor
        /// class. This will automatically go off and build any effects or textures
        /// that are referenced by the material. When you load the resulting material
        /// at runtime, you will get back an Effect instance that has the appropriate
        /// textures already loaded into it and ready to go.
        /// </summary>
        MaterialContent ProcessMaterial(MaterialContent material)
        {
            // Have we already processed this material?
            if (!processedMaterials.ContainsKey(material))
            {
                // If not, process it now.
                processedMaterials[material] =
                    context.Convert<MaterialContent,
                                    MaterialContent>(material, "MaterialProcessor");
            }

            return processedMaterials[material];
        }
    }
}