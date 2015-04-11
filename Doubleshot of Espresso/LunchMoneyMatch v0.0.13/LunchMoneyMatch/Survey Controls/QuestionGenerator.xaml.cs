using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LunchMoneyMatch.Survey_Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class QuestionGenerator : Window
    {
        Question question;

        public QuestionGenerator()
        {
            InitializeComponent();
            #region Trait Combobox items
            TraitComboBox.Items.Add("Optimistic Vs Critical");
            TraitComboBox.Items.Add("Work Vs FamilyOriented");
            TraitComboBox.Items.Add("Arrogant Vs Humble");
            TraitComboBox.Items.Add("TeamPlayer Vs SelfReliant");
            TraitComboBox.Items.Add("Old Fashioned Vs Experimenter");
            TraitComboBox.Items.Add("Written Vs Oral Communication");
            TraitComboBox.Items.Add("Profesional Vs Personalized");
            TraitComboBox.Items.Add("Energetic Vs Reserved");
            TraitComboBox.Items.Add("Single Task Vs Multi-Task");
            TraitComboBox.Items.Add("Leader Vs Follower");
            TraitComboBox.Items.Add("Creative Vs Logical");
            TraitComboBox.Items.Add("Emotionless Vs Emotional");
            TraitComboBox.Items.Add("Dominant Vs Submissive");
            TraitComboBox.Items.Add("Serious Vs Lively");
            TraitComboBox.Items.Add("Non-Conformative Vs Open Minded");
            TraitComboBox.Items.Add("Tolerates Disorder Vs Perfectionist");
            TraitComboBox.Items.Add("Sensitive Vs Unsentimental");
            TraitComboBox.Items.Add("Moral Vs Willing to bend rules");
            TraitComboBox.Items.Add("Organized Vs. Think on your feet");
            TraitComboBox.Items.Add("Big Picture vs. Small Details");
            TraitComboBox.Items.Add("Office Setting Vs Social Butterfly");
            TraitComboBox.Items.Add("Play it safe Vs  Willing to take risks");
            TraitComboBox.Items.Add("Internalizer Vs Externalizer");
            TraitComboBox.Items.Add("Role Adaptable Vs Role Uniform");
            TraitComboBox.Items.Add("Wide Variety of Knowledge Vs Deep Knowledge");
            TraitComboBox.Items.Add("Action Vs Thought Oriented");
            TraitComboBox.Items.Add("Gut- Feeling Vs Logical Decision Maker");
            TraitComboBox.Items.Add("Aggressive Vs Passive");
            TraitComboBox.Items.Add("Self-Learners vs Willing to learn from others");
            TraitComboBox.Items.Add("Personal Problem resolver Vs 'Just get over it");
            TraitComboBox.Items.Add("Inspires Vs Hard Worker");
            TraitComboBox.Items.Add("On case by case basis Vs Broad Rules");
            TraitComboBox.Items.Add("Purposeful Vs Need the money");
            
            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (questionBox.Text != "" && TraitComboBox.SelectedIndex != -1 && answerABox.Text != "" && answerBBox.Text != "" && answerCBox.Text != "" && answerDBox.Text != "")
            {
                question = new Question(questionBox.Text, (PrimaryTrait)TraitComboBox.SelectedIndex, (SecondaryTrait)TraitComboBox.SelectedIndex, answerABox.Text, answerBBox.Text, answerCBox.Text, answerDBox.Text);
                QuestionGeneratorConfirmationDialog win = new QuestionGeneratorConfirmationDialog(question);
                if (win.ShowDialog() == true)
                {
                    passQuestionToServer();
                }
            }
        }
        /// <summary>
        /// TODO: Establish connection with server, pass question into database, close database
        /// Database should keep track of what number question this is to be able to keep track of which questions the user has answered
        /// </summary>
        private void passQuestionToServer()
        {

        }

        private void TraitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            primTraitLabel.Content = "Primary Trait: " + ((PrimaryTrait)TraitComboBox.SelectedIndex).ToString();
            secTraitLabel.Content = "Secondary Trait: " + ((SecondaryTrait)TraitComboBox.SelectedIndex).ToString();
        }
    }
}
