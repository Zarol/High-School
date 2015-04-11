/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
 

import java.util.ArrayList;

/**
 *
 * @author student
 */
public class cellStack {

    ArrayList<Cell> listCells;

    public cellStack() {
        listCells = new ArrayList<Cell>();
    }

    public void pushCell(Cell newCell) {
        listCells.add(0, newCell);
    }

    public Cell popCell() {
        Cell tempCell = listCells.get(0);
        listCells.remove(0);
        return tempCell;
    }
}
