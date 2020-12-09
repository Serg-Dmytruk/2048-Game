using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Windows.Controls;
namespace CyberPunk2048
{
    class ButtonsContrloller
    {
        int[,] logickArray = new int[4, 4];
        int[,] winCheckLogickArray = new int[4, 4];
        private ButtonValuePoint point = new ButtonValuePoint();
        private int winth, height;
        public int score = 0, maxScore = 0;
       public ButtonsContrloller (int winth, int height)
       {
            this.winth = winth;
            this.height = height;
         
            for(int i = 0; i < this.height; i++)
                for (int j = 0; j < this.winth; j++)
                    logickArray[i, j] = 0;
       }
       public ButtonValuePoint GenerateNewButtons()
       {
            int whatRnd = 0;
            Random rndValue = new Random(DateTime.Now.Millisecond);
            if (rndValue.Next(0, 9) == 8)
                whatRnd = 4;
            else
                whatRnd = 2;
            GenerateCoordinate(whatRnd.ToString());
            return point;
        }

        private void GenerateCoordinate(string value)
        {
            Random spawnPoint = new Random(DateTime.Now.Millisecond);
            ArrayList listWithEmptySlots = new ArrayList();
            for (int i = 0; i < winth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (logickArray[i, j] == 0)
                    {
                        ButtonValuePoint coordinate = new ButtonValuePoint();
                        coordinate.x = i;
                        coordinate.y = j;
                        listWithEmptySlots.Add(coordinate);
                    }
                }
            }
            if (listWithEmptySlots.Count != 0)
            {
                int index = spawnPoint.Next(0, listWithEmptySlots.Count);
                point.x = ((ButtonValuePoint)listWithEmptySlots[index]).x;
                point.y = ((ButtonValuePoint)listWithEmptySlots[index]).y;
                point.value = value;
                logickArray[point.x, point.y] = Convert.ToInt32(point.value);
            }
        }
        public void MoveToUp()
        {
            for (int i = 0; i < winth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (logickArray[i, j] != 0)
                    {
                        int newTmpYCoordinate = i;
                        if (newTmpYCoordinate - 1 >= 0)
                        {
                            newTmpYCoordinate--;
                            int oldTmpYCoordinate = i;

                            while (CanIMove(newTmpYCoordinate, oldTmpYCoordinate, j, "Up"))
                            {
                                if (logickArray[newTmpYCoordinate, j] == 0)
                                {
                                    logickArray[newTmpYCoordinate, j] = logickArray[oldTmpYCoordinate, j];
                                    logickArray[oldTmpYCoordinate, j] = 0;
                                }
                                else if (logickArray[newTmpYCoordinate, j] == logickArray[oldTmpYCoordinate, j])
                                {
                                    logickArray[newTmpYCoordinate, j] = logickArray[newTmpYCoordinate, j] + logickArray[oldTmpYCoordinate, j];
                                    logickArray[oldTmpYCoordinate, j] = 0;
                                    score += logickArray[newTmpYCoordinate, j];
                                    if (score > maxScore)
                                        maxScore = score;
                                    break;
                                }
                                newTmpYCoordinate--;
                                oldTmpYCoordinate--;
                            }
                        }
                    }
                }
            }
            winCheckLogickArray = logickArray;
        }
        public void MoveToLeft()
        {
            for (int i = 0; i < winth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (logickArray[i, j] != 0)
                    {
                        int newTmpXCoordinate = j;
                        if (newTmpXCoordinate - 1 >= 0)
                        {
                            newTmpXCoordinate--;
                            int oldTmpXCoordinate = j;

                            while (CanIMove(newTmpXCoordinate, oldTmpXCoordinate, i, "Left"))
                            {
                                if (logickArray[i, newTmpXCoordinate] == 0)
                                {
                                    logickArray[i, newTmpXCoordinate] = logickArray[i, oldTmpXCoordinate];
                                    logickArray[i, oldTmpXCoordinate] = 0;
                                }
                                else if (logickArray[i, newTmpXCoordinate] == logickArray[i, oldTmpXCoordinate])
                                {
                                    logickArray[i, newTmpXCoordinate] = logickArray[i, newTmpXCoordinate] + logickArray[i, oldTmpXCoordinate];
                                    logickArray[i, oldTmpXCoordinate] = 0;
                                    score += logickArray[i, newTmpXCoordinate];
                                    if (score > maxScore)
                                        maxScore = score;
                                    break;
                                }
                                newTmpXCoordinate--;
                                oldTmpXCoordinate--;
                            }
                        }
                    }
                }
            }
            winCheckLogickArray = logickArray;
        }
        public void MoveToDown()
        {
            for (int i = winth - 1; i >= 0; i--)
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    if (logickArray[i, j] != 0)
                    {
                        int newTmpYCoordinate = i;
                        if (newTmpYCoordinate + 1 < 4)
                        {
                            newTmpYCoordinate++;
                            int oldTmpYCoordinate = i;

                            while (CanIMove(newTmpYCoordinate, oldTmpYCoordinate, j, "Down"))
                            {
                                if (logickArray[newTmpYCoordinate, j] == 0)
                                {
                                    logickArray[newTmpYCoordinate, j] = logickArray[oldTmpYCoordinate, j];
                                    logickArray[oldTmpYCoordinate, j] = 0;
                                }
                                else if (logickArray[newTmpYCoordinate, j] == logickArray[oldTmpYCoordinate, j])
                                {
                                    logickArray[newTmpYCoordinate, j] = logickArray[newTmpYCoordinate, j] + logickArray[oldTmpYCoordinate, j];
                                    logickArray[oldTmpYCoordinate, j] = 0;
                                    score += logickArray[newTmpYCoordinate, j];
                                    if (score > maxScore)
                                        maxScore = score;
                                    break;
                                }
                                newTmpYCoordinate++;
                                oldTmpYCoordinate++;
                            }
                        }
                    }
                }
            }
            winCheckLogickArray = logickArray;
        }
        public void MoveToRight()
        {
            for (int i = winth - 1; i >= 0; i--)
            {
                for (int j = height - 1; j >= 0; j--)
                {
                    if (logickArray[i, j] != 0)
                    {
                        int newTmpXCoordinate = j;
                        if (newTmpXCoordinate + 1 < 4)
                        {
                            newTmpXCoordinate++;
                            int oldTmpXCoordinate = j;

                            while (CanIMove(newTmpXCoordinate, oldTmpXCoordinate, i, "Right"))
                            {
                                if (logickArray[i, newTmpXCoordinate] == 0)
                                {
                                    logickArray[i, newTmpXCoordinate] = logickArray[i, oldTmpXCoordinate];
                                    logickArray[i, oldTmpXCoordinate] = 0;
                                }
                                else if (logickArray[i, newTmpXCoordinate] == logickArray[i, oldTmpXCoordinate])
                                {
                                    logickArray[i, newTmpXCoordinate] = logickArray[i, newTmpXCoordinate] + logickArray[i, oldTmpXCoordinate];
                                    logickArray[i, oldTmpXCoordinate] = 0;
                                    score += logickArray[i, newTmpXCoordinate];
                                    if (score > maxScore)
                                        maxScore = score;
                                    break;
                                }
                                newTmpXCoordinate++;
                                oldTmpXCoordinate++;
                            }
                        }
                    }
                }
            }
            winCheckLogickArray = logickArray;
        }
        public int[,] GetLogicArray()
        {
            return logickArray;
        }
        private bool CanIMove(int newCoordinate, int oldCoordinate , int constCoordinate, string funcPatam)
        {
            if (funcPatam == "Up")
            {
                if ((newCoordinate >= 0 && newCoordinate < 4) && (constCoordinate >= 0 && constCoordinate < 4))
                {
                    if (logickArray[newCoordinate, constCoordinate] == 0)
                        return true;
                    else if (logickArray[newCoordinate, constCoordinate] == logickArray[oldCoordinate, constCoordinate])
                        return true;
                    else
                        return false;
                }
                return false;
            }
            else if (funcPatam == "Left")
            {
                if ((newCoordinate >= 0 && newCoordinate < 4) && (constCoordinate >= 0 && constCoordinate < 4))
                {
                    if (logickArray[constCoordinate, newCoordinate] == 0)
                        return true;
                    else if (logickArray[constCoordinate, newCoordinate] == logickArray[constCoordinate, oldCoordinate])
                        return true;
                    else
                        return false;
                }
                return false;
            }
            if (funcPatam == "Down")
            {
                if ((newCoordinate >= 0 && newCoordinate < 4) && (constCoordinate >= 0 && constCoordinate < 4))
                {
                    if (logickArray[newCoordinate, constCoordinate] == 0)
                        return true;
                    else if (logickArray[newCoordinate, constCoordinate] == logickArray[oldCoordinate, constCoordinate])
                        return true;
                    else
                        return false;
                }
                return false;
            }
            else if (funcPatam == "Right")
            {
                if ((newCoordinate >= 0 && newCoordinate < 4) && (constCoordinate >= 0 && constCoordinate < 4))
                {
                    if (logickArray[constCoordinate, newCoordinate] == 0)
                        return true;
                    else if (logickArray[constCoordinate, newCoordinate] == logickArray[constCoordinate, oldCoordinate])
                        return true;
                    else
                        return false;
                }
                return false;
            }
            return false;
        }
        public bool WinCheck()
        {
            if (score >= 2048)
                return true;
            else
                return false;
        }
        public bool GameOver()
        {
            for(int i = 0; i < winth; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if (winCheckLogickArray[i, j] != logickArray[i, j] || winCheckLogickArray[i, j] == 0)
                        return false;
                }
            }
            for (int i = 0; i < winth; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    logickArray[i, j] = 0;
                }
            }
            return true;
        }
    }
}
