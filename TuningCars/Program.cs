using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuningCars
{
    class Program
    {
        static int Menu(List<string> originalTuningList, List<string> List, string auto, List<string> tuningCarsList, int nIndex)
        {
            int nSelect = 0;

            while (true)
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("Auto:");
                Console.ResetColor();
                Console.WriteLine(" " + auto);

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("Tuning:");
                Console.ResetColor();

                if (nIndex != -1)
                {
                    if (nIndex == 1) nIndex = 5;
                    if (nIndex == 2) nIndex = 10;
                    if (nIndex == 3) nIndex = 15;
                    if (nIndex == 4) nIndex = 20;

                    for (int i = nIndex; i < nIndex + 5; i++)
                    {
                        if (originalTuningList[i] != tuningCarsList[i])
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(" " + tuningCarsList[i]);
                            Console.ResetColor();
                        }
                        else
                            Console.Write(" " + tuningCarsList[i]);

                    }
                }

                Console.WriteLine("\n-------------------");
                for (int i = 0; i < List.Count; i++)
                {
                    if (i == nSelect)
                    {
                        Console.Write(" ► ");
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(List[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("   " + List[i]);
                    }
                }
                Console.WriteLine("-------------------");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (nSelect == 0) nSelect = List.Count - 1;
                        else nSelect--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (nSelect >= List.Count - 1) nSelect = 0;
                        else nSelect++;
                        break;
                    case ConsoleKey.Enter:
                        return nSelect;
                }
            }
        }

        static void Main(string[] args)
        {
            #region

            List<string> engineList = null;
            List<string> drivetrainList = null;
            List<string> forcedInductionList = null;
            List<string> suspensionList = null;
            List<string> nitrousOxideList = null;

            if (File.Exists(@"Engines.txt"))
                engineList = File.ReadAllLines(@"Engines.txt").ToList();
            if (File.Exists(@"Drivetrains.txt"))
                drivetrainList = File.ReadAllLines(@"Drivetrains.txt").ToList();
            if (File.Exists(@"ForcedInduction.txt"))
                forcedInductionList = File.ReadAllLines(@"ForcedInduction.txt").ToList();
            if (File.Exists(@"Suspensions.txt"))
                suspensionList = File.ReadAllLines(@"Suspensions.txt").ToList();
            if (File.Exists(@"NitrousOxide.txt"))
                nitrousOxideList = File.ReadAllLines(@"NitrousOxide.txt").ToList();

            int nClick, nIndex = -1, nTuning;
            string auto = "Car is not selected !";

            List<string> originalTuningList = new List<string>
                    {
                        "Engine1",
                        "Drivetrain1",
                        "ForcedInduction1",
                        "Suspension1",
                        "NitrousOxide1",
                        "Engine2",
                        "Drivetrain2",
                        "ForcedInduction2",
                        "Suspension2",
                        "NitrousOxide2",
                        "Engine3",
                        "Drivetrain3",
                        "ForcedInduction3",
                        "Suspension3",
                        "NitrousOxide3",
                        "Engine4",
                        "Drivetrain4",
                        "ForcedInduction4",
                        "Suspension4",
                        "NitrousOxide4",
                        "Engine5",
                        "Drivetrain5",
                        "ForcedInduction5",
                        "Suspension5",
                        "NitrousOxide5"
                    };

            List<string> mainList = new List<string>
            {
                "Garage",
                "Tuning",
                "Save"
            };

            List<string> carsList = new List<string>
            {
                "Peugeot",
                "Porsche",
                "Lamborghini",
                "Ferrari",
                "Jaguar"
            };

            List<string> tuningList = new List<string>
            {
                "Engine", // двигатель
                "Drivetrain", // трансмиссия
                "ForcedInduction", // турбонаддув
                "Suspension", // Подвеска
                "NitrousOxide" // Окись азота
            };

            #endregion

            var tuningCarsList = File.Exists(@"savingTuning.txt") ? File.ReadAllLines(@"savingTuning.txt").ToList() : originalTuningList.ToList();

            while (true)
            {
                nClick = Menu(originalTuningList, mainList, auto, tuningCarsList, nIndex);

                if (nClick == 0)
                {
                    auto = carsList[nIndex = Menu(originalTuningList, carsList, auto, tuningCarsList, nIndex)];
                }
                else if (nClick == 1 && auto == "Car is not selected !" || auto == "Please select a car...")
                {
                    auto = "Please select a car...";
                }
                else
                {
                    if (nClick == 2)
                    {
                        File.WriteAllLines(@"savingTuning.txt", tuningCarsList);
                    }
                    else
                    {
                        nTuning = Menu(originalTuningList, tuningList, auto, tuningCarsList, nIndex);

                        if (nIndex == 1) nIndex = 5;
                        if (nIndex == 2) nIndex = 10;
                        if (nIndex == 3) nIndex = 15;
                        if (nIndex == 4) nIndex = 20;

                        if (nTuning == 0)
                        {
                            if (engineList != null)
                                tuningCarsList.Insert(nIndex, engineList[Menu(originalTuningList, engineList, auto, tuningCarsList, nIndex)]);

                            tuningCarsList.RemoveAt(nIndex + 1);
                        }
                        else
                        {
                            if (nTuning == 1)
                            {
                                if (drivetrainList != null)
                                    tuningCarsList.Insert(nIndex + 1, drivetrainList[Menu(originalTuningList, drivetrainList, auto, tuningCarsList, nIndex)]);

                                tuningCarsList.RemoveAt(nIndex + 2);
                            }
                            else
                            {
                                if (nTuning == 2)
                                {
                                    if (forcedInductionList != null)
                                        tuningCarsList.Insert(nIndex + 2, forcedInductionList[Menu(originalTuningList, forcedInductionList, auto, tuningCarsList, nIndex)]);

                                    tuningCarsList.RemoveAt(nIndex + 3);
                                }
                                else
                                {
                                    if (nTuning == 3)
                                    {
                                        if (suspensionList != null)
                                            tuningCarsList.Insert(nIndex + 3, suspensionList[Menu(originalTuningList, suspensionList, auto, tuningCarsList, nIndex)]);

                                        tuningCarsList.RemoveAt(nIndex + 4);
                                    }
                                    else
                                    {
                                        if (nitrousOxideList != null)
                                            tuningCarsList.Insert(nIndex + 4, nitrousOxideList[Menu(originalTuningList, nitrousOxideList, auto, tuningCarsList, nIndex)]);

                                        tuningCarsList.RemoveAt(nIndex + 5);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
