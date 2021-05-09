using System;
using System.Collections.Generic;

//beste Sortieralgorithmus raussuchen,
//hash funktion einbinden
//boyer-moore einbinden

class Algorithmen
{
    int GesamtVergleiche;
    int GesamtTauschen;
    Algorithmen(int GesamtVergleiche, int GesamtTauschen)
    {
        this.GesamtVergleiche = GesamtVergleiche;
        this.GesamtTauschen = GesamtTauschen;
    }
    static void Main()
    {
    hier:
        List<double> list = new List<double>(); List<double> Relation = new List<double>();
        string x = ""; double L = 0; bool sucheWort = false;
        Algorithmen Alg = new Algorithmen(0, 0);
        int k = 0;
        string pattern = "", SuchText = "";


        Console.WriteLine("Nr.\tAlgorithmus\n1\tLineare Suche\n2\tbinäre Suche\n\n" +
            "3\tbubbleSort\n4\tSelectionSort\n5\tInsertionSort\n6\tquickSort\n7\tmergeSort\n8\tHeapSort\n\n9\tMaxSearch\n" +
            "10\tMinMaxSearch Turniermethode\n11\tk-BubbleSelection\n12\tQuickSelection\n\n20\tMatching\n21\tKMP-Matching\n22\tBoyer-Moore\n" +
            "23\tRabin-Karp-Matching\n\n30\tRelationen\n\n");
        int Nr = Int32.Parse(Console.ReadLine());
        Console.Clear();
        //int Nr = 23;
        Console.ForegroundColor = ConsoleColor.Red;
        switch (Nr)
        {
            case 1:
                Console.WriteLine("Lineare Suche");
                break;
            case 2:
                Console.WriteLine("binäre Suche");
                break;
            case 3:
                Console.WriteLine("bubbleSort");
                break;
            case 4:
                Console.WriteLine("SelectionSort"); Console.WriteLine("\nDas kleinste Element wandert immer nach vorne\n");
                break;
            case 5:
                Console.WriteLine("InsertionSort"); Console.WriteLine("\nDie Elemente werden von links beginnend verglichen und in einer neuen Liste sortiert");
                break;
            case 6:
                Console.WriteLine("quickSort");
                break;
            case 7:
                Console.WriteLine("mergeSort");
                break;
            case 8:
                Console.WriteLine("Heapsort");
                break;
            case 9: Console.WriteLine("Max Search"); break;
            case 10:
                Console.WriteLine("MinMaxSearch Turniermethode");
                break;

            case 11:
                Console.WriteLine("k-BubbleSelection");
                break;
            case 12:
                Console.WriteLine("QuickSelection");
                break;
            case 20: Console.WriteLine("Matching"); break;
            case 21: Console.WriteLine("KMP-Matching"); break;
            case 22: Console.WriteLine("Boyer-Moore"); break;
            case 23: Console.WriteLine("Rabin-Karp-Matching"); break;
            case 30: Console.WriteLine("Relationen"); break;
        }
        Console.ForegroundColor = ConsoleColor.White;
        if (Nr > 0 && Nr < 13 || Nr == 50)
        {
            Console.WriteLine("Liste eingeben"); Console.Write("L={");
            x = Console.ReadLine();
            if (x[x.Length - 1] == ',')
            {
                x = x.Remove(x.Length - 1); //if last char is an ',' , it will be removed
            }
            var arguments = x.Split(',');
            for (int i = 0; i < arguments.Length; i++)
            {
                double.TryParse(arguments[i], out L); //x
                list.Add(L);
            }
            if (Nr != 7 && Nr != 8) print(list);
            x = "";
        }
        else if (Nr > 19 && Nr < 30)
        {
            Console.WriteLine("Hier Text eingeben, wodrin gesucht wird (Suchstring)");
            SuchText = Console.ReadLine();
            Console.WriteLine("das suchende Wort eingeben (Pattern)");
            pattern = Console.ReadLine();
            //SuchText = "852467384194";
            //pattern = "841";

        }
        else if (Nr > 29 && Nr < 40)
        {
            Console.WriteLine("Menge eingeben");
            Console.Write("M={"); x = Console.ReadLine();
            if (x[x.Length - 1] == ',')
            {
                x = x.Remove(x.Length - 1); //if last char is an ',' , it will be removed
            }
            var arguments = x.Split(',');
            for (int i = 0; i < arguments.Length; i++)
            {
                double.TryParse(arguments[i], out L); //x
                list.Add(L);
            }

            Console.Write("Relation={"); x = Console.ReadLine();
            arguments = x.Split(',');
            string[] reslts = x.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < reslts.Length; i++)
            {
                double.TryParse(reslts[i], out L); //Relation
                Relation.Add(L);
            }

        }

        if (Nr > 2 && Nr < 6) { Console.WriteLine("\n\n\tListe\t\t\tnächste Aktion\t\tbenötigte Vergleiche"); }
        else if (Nr > 10 && Nr < 13) { Console.Write("k="); k = Int32.Parse(Console.ReadLine()); Console.WriteLine(); }

        double kmax;
        switch (Nr)
        {
            case 1:
                L = wort(); sucheWort = Alg.lineareSuche(list, L);
                break;
            case 2:
                L = wort(); sucheWort = Alg.binaereSuche(list, L);
                break;
            case 3:
                list = Alg.bubbleSort(list);
                break;
            case 4:
                list = Alg.selectionSort(list);
                break;
            case 5:
                list = Alg.inertionSort(list);
                break;
            case 6:
                Console.WriteLine("\nDie folgende Abbildung zeigt die Pivot-Elemente rot.Darunter die entsprechenden Teillisten A1 und A2. Asort= A1, pivot, A2");
                printPivot(list); Console.WriteLine();
                list = Alg.quickSort(list);
                break;
            case 7:
                print(list); Console.WriteLine();
                list = Alg.mergeSort(list);
                break;
            case 8:
                list = Alg.HeapSort(list);
                break;
            case 9:
                list = Alg.maxSearch(list);
                break;
            case 10:
                list = Alg.minMaxSearch(list);
                break;
            case 11:
                kmax = Alg.KBubleSelection(list, k);
                break;
            case 12:
                kmax = Alg.QuickSelection(list, k);
                break;
            case 20: sucheWort = Alg.matching(pattern, SuchText); break;
            case 21: sucheWort = Alg.KMPMatching(pattern, SuchText); break;
            case 22: sucheWort = Alg.BoyerMoore(pattern, SuchText); break;
            case 23: sucheWort = Alg.RabinKarp(pattern, SuchText); break;
            case 30: bool relation = Alg.relation(list, Relation); break;
        }

        if (Nr > 5 && Nr < 9) { Console.Write("Asort="); print(list); }

        if (Nr == 1 || Nr == 2)
        {
            Console.WriteLine("ist " + L + " in der Liste?\n" + sucheWort);
        }

        Console.WriteLine("\n\nDrücke Enter um von vorne zu Beginnen");
        x = Console.ReadLine();
        Console.WriteLine();
        Console.Clear();
        goto hier;
    }
    static void print(List<double> list)
    {
        Console.Write("L=[");
        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                Console.Write(list[i]);
            }
            else Console.Write(list[i] + ", ");
        }
        Console.Write("]");
    }
    static void printInsert(List<double> list, int x)
    {
        Console.Write("L=[");
        for (int i = 0; i < list.Count; i++)
        {
            if (i > x)
            {
                if (i == list.Count - 1)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(" " + ", ");
                }

            }
            else
            {
                if (i == list.Count - 1)
                {
                    Console.Write(list[i]);
                }
                else Console.Write(list[i] + ", ");
            }
        }
        Console.Write("]");
    }

    static void printMenge(List<double> list, char V)
    {
        Console.Write(V + "={");
        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                Console.Write(list[i]);
            }
            else Console.Write(list[i] + ", ");
        }
        Console.WriteLine("}");
    }
    static void printRelation(List<double> Relation)
    {
        Console.Write("R={");
        for (int i = 0; i < Relation.Count; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("(" + Relation[i] + ",");
            }
            else if (i == Relation.Count - 1)
            {
                Console.Write(Relation[i] + ")");
            }
            else if (i % 2 == 1)
            {
                Console.Write(Relation[i] + "), ");
            }
        }
        Console.WriteLine("}");
    }
    static void printP(List<double> Relation)
    {
        Console.Write("{");
        for (int i = 0; i < Relation.Count; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write("(" + Relation[i] + ",");
            }
            else if (i == Relation.Count - 1)
            {
                Console.Write(Relation[i] + ")");
            }
            else if (i % 2 == 1)
            {
                Console.Write(Relation[i] + "), ");
            }
        }
        Console.Write("}");
    }
    static void printTransitiv(List<double> R)
    {
        for (int i = 0; i < R.Count; i += 6)
        {
            Console.WriteLine("{(" + R[i] + "," + R[i + 1] + "), (" + R[i + 2] + "," + R[i + 3] + ")} Element of R aber (" + R[i + 4] + "," + R[i + 5] + ") kein Element von R ist");
        }
    }
    static void Aprint(List<double> list)
    {
        Console.Write("Asort=[");
        for (int i = 0; i < list.Count; i++)
        {
            if (i == list.Count - 1)
            {
                Console.Write(list[i]);
            }
            else Console.Write(list[i] + ", ");
        }
        Console.WriteLine("]");
    }
    static void smallPrint(List<double> L, int first, int last)
    {
        for (int i = first; i <= last; i++)
        {
            if (i == L.Count - 1)
            {
                Console.Write(L[i]);
            }
            else Console.Write(L[i] + ", ");
        }
        Console.WriteLine();

    }
    static void printPivot(List<double> list)
    {
        Console.Write("L=[");
        for (int i = 0; i < list.Count; i++)
        {
            if (list.Count == 1)
            {
                Console.Write(list[i]);
            }
            else if (i == list.Count / 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(list[i]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(", ");
            }
            else if (i == list.Count - 1)
            {
                Console.Write(list[i]);
            }
            else Console.Write(list[i] + ", ");
        }
        Console.Write("]  ");

    }
    static void missMatch(string Miss, int i)
    {
        for (int x = 0; x < Miss.Length; x++)
        {
            if (x == i)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (Miss[x] == ' ') { Console.Write("_"); }
                else { Console.Write(Miss[x]); }
                Console.ResetColor();
            }
            else { Console.Write(Miss[x]); }
        }
    }
    static double wort()
    {
        Console.WriteLine("Bitte w eintragen");
        double w = double.Parse(Console.ReadLine());
        Console.WriteLine();
        return w;
    }
    //Algorithmen
    bool lineareSuche(List<double> L, double w)
    {
        int i = 0;
        while (i < L.Count)
        {
            if (L[i] == w) return true;
            i++;
        }
        return false;
    }
    bool binaereSuche(List<double> L, double w)
    { //Es wird immer geguckt, ob das Element in der Mitte < > = w ist. Je nachdem wird nur noch eine Hälfte betrachtet.
        Console.WriteLine("Code\t\tAusführungen\tin den Elementen wird weiter gesucht");
        int first = 0;
        int last = L.Count - 1;
        while (first <= last)
        {
            int middle = (first + last) / 2;
            if (L[middle] < w)
            {
                first = middle + 1;
                Console.Write("List[mid]<w ==\t " + L[middle] + "<" + w + "\t\t");
            }
            else
            {
                if (L[middle] == w)
                {
                    return true;
                }
                last = middle - 1;
                Console.Write("List[mid]>w ==\t " + L[middle] + ">" + w + "\t\t");
            }
            smallPrint(L, first, last);
        }
        return false;
    }
    List<double> bubbleSort(List<double> A)
    { //Die höchste Zahl wandert nach hinten
        int Vergleiche = 0, Tauschen = 0; GesamtTauschen = 0; GesamtVergleiche = 0;
        print(A);
        for (int i = 0; i < A.Count; i++)
        {
            for (int j = 0; j < A.Count - (i + 1); j++)
            {
                Vergleiche++; GesamtVergleiche++;
                if (A[j] > A[j + 1])
                {
                    double temp = A[j];
                    A[j] = A[j + 1];
                    A[j + 1] = temp;
                    Console.Write("\t" + A[j] + " swap " + A[j + 1] + "\t\t" + Vergleiche + "x\n");
                    print(A);
                    Tauschen++;
                    Vergleiche = 0;
                }
            }
        }
        if (Vergleiche != 0) Console.WriteLine("\t\t\t\t" + Vergleiche + ("x"));
        Console.WriteLine("\n" + Tauschen + "x wurde getauscht \t" + GesamtVergleiche + "x wurde verglichen\n");
        return A;
    }
    List<double> selectionSort(List<double> A)
    { //Die kleinste Zahl wandert nach vorne
        int Vergleiche = 0, Tauschen = 0; GesamtVergleiche = 0; GesamtTauschen = 0;
        print(A);
        for (int i = 0; i < A.Count; i++)
        {
            int min = i;
            for (int j = i + 1; j < A.Count; j++)
            {
                Vergleiche++; GesamtVergleiche++;
                if (A[j] < A[min]) { min = j; Tauschen++; }
            }
            double temp = A[i];
            A[i] = A[min];
            A[min] = temp;
            Console.Write("\t" + A[i] + " swap " + A[min] + "\t\t" + Vergleiche + "x\n");
            print(A);
            Vergleiche = 0;
        }
        Console.WriteLine("\n" + Tauschen + "x wurde getauscht \t" + GesamtVergleiche + "x wurde verglichen\n");
        return A;
    }
    List<double> inertionSort(List<double> A)
    {
        int Vergleiche, Tauschen; GesamtTauschen = 0; GesamtVergleiche = 0;
        print(A); Console.WriteLine();
        printInsert(A, 0);
        for (int i = 1; i < A.Count; i++)
        {
            double key = A[i];
            int j = i - 1;
            Vergleiche = 0; Tauschen = 0; if (j >= 0) Vergleiche++;
            while (j >= 0 && A[j] > key)
            {
                A[j + 1] = A[j];
                j = j - 1;
                if (j >= 0) Vergleiche++;
                Tauschen++;
                Console.Write("\t" + A[j + 1] + " swap " + key);
            }
            A[j + 1] = key;
            GesamtVergleiche += Vergleiche; GesamtTauschen += Tauschen;
            Console.Write("\t\t" + Vergleiche + "x" + "\n");
            printInsert(A, i);
        }
        Console.WriteLine("\n" + GesamtTauschen + "x wurde getauscht \t" + GesamtVergleiche + "x wurde verglichen\n");
        return A;
    }
    List<double> quickSort(List<double> A)
    {
        //Die pfade werden von links her aufgebaut, sobald eine pfadrichtung beendet ist, wird eine Zeile freigelassen
        if (A.Count <= 1) { return A; }

        int pivot = (A.Count / 2);
        List<double> A1 = new List<double>();
        List<double> A2 = new List<double>();
        for (int i = 0; i < A.Count; i++)
        {
            if (i != pivot && A[i] <= A[pivot]) A1.Add(A[i]);
            if (i != pivot && A[i] > A[pivot]) A2.Add(A[i]);
        }
        List<double> Asort = new List<double>();
        printPivot(A1);
        printPivot(A2); Console.WriteLine();
        Asort.AddRange(quickSort(A1));
        Aprint(Asort);
        Asort.Add(A[pivot]); Console.WriteLine(); Aprint(Asort);
        Asort.AddRange(quickSort(A2));
        Aprint(Asort);

        return Asort;
    }
    List<double> mergeSort(List<double> A)
    {
        //print(A); Console.WriteLine();
        if (A.Count <= 1) return A;

        int pivot = (A.Count / 2);
        List<double> A1 = new List<double>();
        List<double> A2 = new List<double>();
        for (int i = 0; i < A.Count; i++)
        {
            if (i < pivot) A1.Add(A[i]);
            if (i >= pivot) A2.Add(A[i]);
        }
        print(A1); Console.WriteLine(); print(A2); Console.WriteLine();
        //rekursiver Aufruf
        List<double> S1 = new List<double>();
        List<double> S2 = new List<double>();
        S1.AddRange(mergeSort(A1));
        S2.AddRange(mergeSort(A2));
        List<double> Asort = new List<double>();
        //weiter mergen
        while ((S1.Count + S2.Count) > 0)
        {
            if ((S1.Count > 0) && (S2.Count > 0))
            {
                if (S1[0] < S2[0])
                {
                    Asort.Add(S1[0]);
                    Aprint(Asort);
                    S1.RemoveAt(0);
                }
                else
                {
                    Asort.Add(S2[0]);
                    Aprint(Asort);
                    S2.RemoveAt(0);
                }
            }
            else
            {
                if (S1.Count > 0)
                {
                    Asort.AddRange(S1);
                    Aprint(Asort);
                    return Asort;
                }
                else
                {
                    Asort.AddRange(S2);
                    Aprint(Asort);
                    return Asort;
                }
            }
        }
        return Asort;
    }
    List<double> HeapSort(List<double> A)
    {
        heapify(A);
        for (int i = A.Count - 1; i >= 0; i--)
        {
            makeSwap(A, 0, i);
            siftDown(A, 0, i - 1);
        }
        return A;

        List<double> heapify(List<double> A)
        {
            for (int start = (A.Count - 2) / 2; start >= 0; start--)
            {
                siftDown(A, start, A.Count - 1);
            }
            return A;
        }
        List<double> siftDown(List<double> A, int p, int end)
        {

            while (p * 2 < end)
            {
                int c = p * 2 + ((p * 2 + 1 < end && A[p * 2 + 2] > A[p * 2 + 1]) ? 2 : 1);
                if (checkSwap(A, c, p)) { p = c; }
                else { return A; }
            }
            return A;
        }
        bool checkSwap(List<double> A, int i, int j)
        {
            if (A[i] > A[j]) { makeSwap(A, i, j); return true; }
            else return false;
        }
        List<double> makeSwap(List<double> A, int i, int j)
        {
            print(A); Console.Write("  " + A[i] + "swap" + A[j] + "\n");
            double key = A[i];
            A[i] = A[j];
            A[j] = key;
            return A;
        }

    }
    List<double> maxSearch(List<double> A)
    {
        if (A.Count < 2)
        {
            Console.WriteLine("liste zu klein"); return A;
        }
        int max = 0;
        for (int i = 0; i < A.Count - 1; i++)
        {
            if (A[i] > A[max]) max = i;
        }
        Console.WriteLine("max = " + A[max]);
        return A;
    }
    List<double> minMaxSearch(List<double> A)
    {
        Console.WriteLine();
        double min = A[0];
        double max = A[0];

        for (int i = 0; i < A.Count - 1; i++)
        {
            if (A[i] < min) { Console.WriteLine(A[i] + "<" + min + "\tmin=" + min); min = A[i]; }
            if (A[i] > max) { Console.WriteLine(A[i] + ">" + max + "\tmax=" + max); max = A[i]; }
        }

        List<double> minMax = new List<double>();
        minMax.Add(max); minMax.Add(min);
        Console.WriteLine("min=" + min + "\tmax=" + max);
        return minMax;
    }
    double KBubleSelection(List<double> A, int k)
    {
        int Vergleiche = 0, Tauschen = 0; GesamtTauschen = 0; GesamtVergleiche = 0;
        print(A);
        for (int i = 1; i <= k; i++)
        {
            for (int j = 0; j < A.Count - 1; j++)
            {
                Vergleiche++; GesamtVergleiche++;
                if (A[j] > A[j + 1])
                {
                    double temp = A[j];
                    A[j] = A[j + 1];
                    A[j + 1] = temp;
                    Console.Write("\t" + A[j] + " swap " + A[j + 1] + "\t\t" + Vergleiche + "x\n");
                    print(A);
                    Tauschen++;
                    Vergleiche = 0;
                }
            }
        }
        if (Vergleiche != 0) Console.WriteLine("\t\t\t\t" + Vergleiche + ("x"));
        Console.WriteLine(Tauschen + "x wurde getauscht \t" + GesamtVergleiche + "x wurde verglichen\t");
        return A[A.Count - k];
    }
    double QuickSelection(List<double> A, int k)
    {
        //Die pfade werden von links her aufgebaut, sobald eine pfadrichtung beendet ist, wird eine Zeile freigelassen
        Console.Write("k=" + k + " und "); printPivot(A); Console.WriteLine();
        if (A.Count <= 1) { return A[A.Count - 1]; }

        int pivot = (A.Count / 2);
        List<double> A1 = new List<double>();
        List<double> A2 = new List<double>();
        for (int i = 0; i < A.Count; i++)
        {
            if (i != pivot && A[i] <= A[pivot]) A1.Add(A[i]);
            if (A[i] > A[pivot]) A2.Add(A[i]);
        }
        //printPivot(A2); Console.WriteLine();
        if (A2.Count >= k) return QuickSelection(A2, k);
        if (A2.Count + 1 == k) return A[pivot];
        return QuickSelection(A1, k - A2.Count - 1);
    }
    bool matching(string pattern, string SuchText)
    {
        Console.WriteLine();
        bool found = false;
        int nrMatched = 0;
        for (int i = 0; i < (SuchText.Length - pattern.Length + 1); i++)
        {
            string space = new string(' ', i);
            Console.Write(space + pattern + "\n" + SuchText);
            nrMatched = 0;
            for (int j = 0; j < pattern.Length; j++)
            {
                if (pattern[j] == SuchText[i + j])
                {
                    nrMatched++;
                }
                if (nrMatched == pattern.Length) { found = true; }
            }
            Console.WriteLine("\tNrMatched=" + nrMatched + "\tfound=" + found);
            if (found == true) return found;
        }
        Console.WriteLine("Das wort wurde gefunden? " + found);
        return found;
    }
    bool KMPMatching(string pattern, string Suchetxt)
    {
        List<int> nextreturn = new List<int>(); bool first = true; string space = "";
        int next(int j, List<int> nreturn)
        {
            if (j <= nreturn.Count) return nreturn[j];
            else return 0;
        }
        string pverkürzt;
        string p2 = pattern.Remove((pattern.Length - 1), 1);
        if (pattern[(pattern.Length - 1)] == '1')
            p2 += '0';
        else
            p2 += '1';
        Console.WriteLine("\t\t\tp =\t" + pattern);
        Console.WriteLine("p' Missmatch an last Position=\t" + p2);
        for (int i = 0; i < pattern.Length; i++)
        {
            Console.WriteLine("\nnext[" + (i) + "] Tabelle erstellen");
            Console.WriteLine("\ni\tp verkürzt\tp' verkürzt\tMatch?\tNext[" + (i) + "]");
            if (i + 1 == pattern.Length) { pverkürzt = pattern; }
            else { pverkürzt = pattern.Remove(i + 1); }

            p2 = pverkürzt.Remove((pverkürzt.Length - 1), 1);
            if (pverkürzt[(pverkürzt.Length - 1)] == '1')
                p2 += '0';
            else
                p2 += '1';

            int Next = 0;
            nextreturn.Add(NextWert(pverkürzt, p2, Next));
        }

        int NextWert(string pverkürzt, string p2, int Next)
        {
            for (int i = 1; i <= p2.Length; i++)
            {
                bool Match = false;
                string pverk, pverk2;
                if (i < p2.Length)
                {
                    pverk = pverkürzt.Remove(i);
                    pverk2 = p2.Remove(0, p2.Length - i);
                }
                else
                {
                    pverk = pverkürzt;
                    pverk2 = p2;
                }
                if (pverk == pverk2) { Match = true; Next = i; }
                Console.WriteLine(i + "\t" + pverk + "\t\t" + pverk2 + "\t\t" + Match + "\t" + Next);
            }
            return Next;
        }


        Console.WriteLine();
        int si = 0, pi = 0;
        while (si < Suchetxt.Length && pi < pattern.Length)
        {
            if (pattern[pi] == Suchetxt[si])
            {
                if (pi == pattern.Length - 1)
                {
                    Console.Write(space); Console.WriteLine(pattern);
                    Console.WriteLine(Suchetxt); return true;
                }
                pi++;
            }
            else
            {
                if (first == true)
                {
                    missMatch(pattern, pi); Console.WriteLine();
                    missMatch(Suchetxt, si); Console.WriteLine();
                }
                else
                {
                    Console.Write(space); missMatch(pattern, pi); Console.WriteLine();
                    missMatch(Suchetxt, si); Console.WriteLine();
                }
                pi = next(pi, nextreturn);
                space = new string(' ', si + 1 - pi);
                first = false;
            }
            si++;
        }
        return false;
    }
    bool BoyerMoore(string pattern, string SucheText)
    {
        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("Boyer-Moore-Matching scannt von hinten," +
            "is nämlich das Zeichen,\ndas wir aus dem Scantext nehmen,weder das letzte Zeichen des Patterns noch ist es überhaupt im " +
            "Pattern vorhanden,\ndann können wir das Pattern gleich vollständig nach rechts schieben.\n" +
            "Ein Match kann niemals an irgendeiner Position dazwischen folgen\n");
        Console.ResetColor();
        int si = pattern.Length - 1, pi = pattern.Length - 1;

        Console.WriteLine(pattern);
        Console.WriteLine(SucheText + "\n\n");
        while (si >= 0 && pi >= 0 && si < SucheText.Length)
        {
            string space;
            if (SucheText[si] == pattern[pi])
            {
                si--; pi--;
                if (pi < 0)
                {
                    space = new string(' ', (si - pi)); Console.WriteLine(space + pattern);
                    Console.WriteLine(SucheText);
                    return true;
                }
            }
            else
            {
                bool gefunden = false;
                for (int i = pattern.Length - 1; i >= 0; i--)
                {
                    if (gefunden == false)
                    {
                        if (SucheText[si] == pattern[i])
                        {
                            if ((si + pattern.Length - 1 - i) < SucheText.Length)
                            {
                                space = new string(' ', (si - pi)); Console.Write(space);
                                missMatch(pattern, pi); Console.WriteLine();
                                missMatch(SucheText, si); Console.WriteLine();
                                si += pattern.Length - 1 - i;
                                gefunden = true;
                            }
                            else
                                return false;
                        }
                    }
                }
                if (gefunden == false)
                {
                    if ((si + pattern.Length < SucheText.Length))
                    {
                        space = new string(' ', (si - pi)); Console.Write(space);
                        missMatch(pattern, pi); Console.WriteLine();
                        missMatch(SucheText, si); Console.WriteLine();
                        si += pattern.Length;
                    }
                    else
                        return false;
                }
                pi = pattern.Length - 1;
            }
        }
        return false;

    }
    bool RabinKarp(string pattern, string SuchText)
    {   
        Console.WriteLine("\nDer Suchstring darf nur aus Ziffern bestehen.\nWähle Methode\n1 = h%Zahl \t 2=h/Zahl");
        int zahl = Int32.Parse(Console.ReadLine());
        if (zahl == 1)
        {
            Console.WriteLine("h=x % Zahl\t\tDie Zahl sollte am besten eine Primzahl sein");
            Console.Write("Zahl = "); zahl = Int32.Parse(Console.ReadLine());
            int p = Int32.Parse(pattern);
            int suchZahl = p % zahl;

            Console.WriteLine("Hashfunktion für das Pattern p(" + pattern + ")%" + zahl + "=" + suchZahl + "\n\n");

            for (int i = 0; i <= SuchText.Length - pattern.Length; i++)
            {
                int suchen = Int32.Parse(SuchText.Substring(i, pattern.Length));
                int x = suchen % zahl;

                if (x == suchZahl)
                {
                    if (suchen != p) Console.WriteLine("h(" + suchen + ")=" + x + " aber " + x + " != " + pattern);
                    else { Console.WriteLine("h(" + suchen + ")=" + x + " und " + x + " = " + pattern); return true; }
                }
                else Console.WriteLine("h(" + suchen + ")=" + x);
            }
            return false;
        }
        else
        {
            Console.WriteLine("h=x / Zahl\t\t");
            Console.Write("Zahl = "); zahl = Int32.Parse(Console.ReadLine());
            int p = Int32.Parse(pattern);
            int suchZahl = p / zahl;

            Console.WriteLine("Hashfunktion für das Pattern p(" + pattern + ")/" + zahl + "=" + suchZahl + "\n\n");

            for (int i = 0; i <= SuchText.Length - pattern.Length; i++)
            {
                int suchen = Int32.Parse(SuchText.Substring(i, pattern.Length));
                int x = suchen / zahl;

                if (x == suchZahl)
                {
                    if (suchen != p) Console.WriteLine("h(" + suchen + ")=" + x + " aber " + x + " != " + pattern);
                    else { Console.WriteLine("h(" + suchen + ")=" + x + " und " + x + " = " + pattern); return true; }
                }
                else Console.WriteLine("h(" + suchen + ")=" + x);
            }
            return false;
        }

    }
    bool relation(List<double> M, List<double> R)
    {

        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\nEine Relation ist eine beliebige Teilmenge des Kreuzprodukts zweier Mengen");
        Console.ResetColor();
        printMenge(M, 'M');
        printRelation(R); Console.WriteLine();
        bool reflexiv = false; bool symmetrie = false; bool Transitivität = false; bool antisymmetrie = false; bool asymmetrie = false;
        bool stop = false;
        List<double> check = new List<double>();
        List<double> sPaar = new List<double>();
        List<double> conter = new List<double>();

        //Reflexivität 
        for (int i = 0; i < M.Count; i++)
        {
            reflexiv = false;
            for (int y = 0; y < R.Count; y += 2)
            {
                if (M[i] == R[y]) //x=x
                {
                    if (M[i] == R[y + 1])
                    {
                        reflexiv = true;
                        check.Add(R[y]); check.Add(R[y + 1]);
                    }
                }
            }
            if (reflexiv == false)
            {
                stop = true; conter.Add(M[i]); conter.Add(M[i]);
            }
        }
        if (stop == false)
        {
            if (reflexiv == true)
            {
                Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("reflexiv"); Console.ResetColor(); Console.Write(" denn für jedes x Element of M ist {x,x} Element of R -->"); printP(check); Console.Write(" Element of R\n\n");
            }
        }
        else
        {
            reflexiv = false;
            Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("nicht reflexiv"); Console.ResetColor(); Console.Write(", weil "); printP(conter); Console.WriteLine(" keine Elemente der Relation sind");
        }
        Console.WriteLine();
        check.Clear(); conter.Clear();
        stop = false;

        //symmetrie 
        for (int i = 0; i < R.Count - 1; i += 2) //xRy 
        {
            symmetrie = false;
            for (int y = 0; y < R.Count; y += 2) //search yRx
            {
                if (R[i + 1] == R[y])
                {
                    if (R[i] == R[y + 1])
                    {
                        symmetrie = true;
                        check.Add(R[y]); check.Add(R[y + 1]);
                    }
                }
            }
            if (symmetrie == false)
            {
                conter.Add(R[i + 1]); conter.Add(R[i]);
                stop = true;
            }
        }
        if (stop == false)
        {
            if (symmetrie == true)
            {
                Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("symmetrisch"); Console.ResetColor(); Console.Write(" denn für jedes (x,y) Element of R gibt es ein {y,x} Element of R -->"); printP(check); Console.Write(" Element of R\n\n");
            }
        }
        else
        {
            symmetrie = false;
            Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("nicht symmetrisch"); Console.ResetColor(); Console.Write(", weil  {"); printP(conter); Console.WriteLine(" keine Elemente der Relation sind");
        }
        check.Clear(); conter.Clear();
        stop = false; Console.WriteLine();
        //Transitivität
        check.Clear();

        for (int x = 0; x < R.Count - 1; x += 2) //x
        {
            bool controll = false;
            Transitivität = false;
            for (int y = 0; y < R.Count; y += 2)
            {
                if (R[x + 1] == R[y])
                {
                    Transitivität = false;
                    controll = true; //if we are here, we know that 2 couples are inside
                    for (int z = 0; z < R.Count; z += 2)
                    {
                        if (R[z] == R[x] && R[z + 1] == R[y + 1])
                        {
                            check.Add(R[x]); check.Add(R[x + 1]); check.Add(R[y]); check.Add(R[y + 1]); check.Add(R[z]); check.Add(R[z + 1]);
                            Transitivität = true;
                        }

                    }
                    if (Transitivität != true)
                    {
                        conter.Add(R[x]); conter.Add(R[x + 1]); conter.Add(R[y]); conter.Add(R[y + 1]); conter.Add(R[x]); conter.Add(R[y + 1]);
                        stop = true;
                    }
                }
                else if (y == R.Count - 2 && controll == false)
                {
                    sPaar.Add(R[x]); sPaar.Add(R[x + 1]);
                    Transitivität = true;
                }
            }
        }
        if (stop == false)
        {
            Transitivität = true;
            Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("transitiv"); Console.ResetColor();
            if (check.Count > 1)
            {
                Console.WriteLine("(x,y) Element of R, (y,z) Element of R und auch (x,z) Element of R");
                printP(check); Console.WriteLine(" ELement of R");
            }
            if (sPaar.Count > 1)
            {
                Console.WriteLine("da sie alleine Stehen und es kein zweites Paar zum vergleichen gibt, sind sie auch Transitiv"); printP(sPaar); Console.WriteLine();
            }
        }
        else
        {
            Transitivität = false;
            Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("nicht transitiv"); Console.ResetColor(); Console.Write(", weil\n");
            printTransitiv(conter);

        }
        Console.WriteLine(); check.Clear(); conter.Clear();
        stop = false;

        //Antisymmetrisch 
        for (int i = 0; i < R.Count - 1; i += 2) //xRy 
        {
            antisymmetrie = true;
            for (int y = 0; y < R.Count; y += 2) //search yRx
            {
                if (R[i + 1] == R[y])
                {
                    if (R[i] == R[y + 1])
                    {
                        if (R[y] == R[y + 1])
                        {
                            antisymmetrie = true;
                        }
                        else
                        {
                            antisymmetrie = false;
                            stop = true;
                            conter.Add(R[y]); conter.Add(R[y + 1]);
                        }
                    }
                }
            }
            if (antisymmetrie == true)
            {
                check.Add(R[i]); check.Add(R[i + 1]);
            }
        }
        if (stop == false)
        {
            if (antisymmetrie == true)
            {
                Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("antisymmetrisch"); Console.ResetColor(); Console.Write(" denn für kein (x,y) Element of R gibt es ein {y,x} Element of R außer wenn x=y -> xRx\n"); printP(check); Console.Write(" Element of R\n\n");
            }
        }
        else
        {
            antisymmetrie = false;
            Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("nicht antisymmetrisch"); Console.ResetColor(); Console.Write(", weil  \n"); printP(conter); Console.WriteLine(" Elemente der Relation sind"); Console.WriteLine();
        }

        check.Clear(); conter.Clear();
        stop = false;

        //Asymmetrische 
        for (int i = 0; i < R.Count - 1; i += 2) //xRy 
        {
            asymmetrie = true;
            for (int y = 0; y < R.Count; y += 2) //search yRx
            {
                if (R[i + 1] == R[y])
                {
                    if (R[i] == R[y + 1])
                    {
                        asymmetrie = false;
                        stop = true;
                        conter.Add(R[y]); conter.Add(R[y + 1]);
                    }
                }
            }
            if (asymmetrie == true)
            {
                check.Add(R[i]); check.Add(R[i + 1]);
            }
        }
        if (stop == false)
        {
            if (asymmetrie == true)
            {
                Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("asymmetrisch"); Console.ResetColor(); Console.Write(" denn für kein (x,y) Element of R gibt es ein {y,x} Element und x ungleich y\n"); printP(check); Console.Write(" Element of R\n\n");
            }
        }
        else
        {
            asymmetrie = false;
            Console.Write("Relation ist "); Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("nicht asymmetrisch"); Console.ResetColor(); Console.Write(", weil \n"); printP(conter); Console.WriteLine(" Elemente der Relation sind");
        }

        check.Clear(); conter.Clear();
        stop = false; Console.WriteLine();

        if (reflexiv == true && symmetrie == true && Transitivität == true)
        {
            Console.WriteLine("\nDamit ist die Äquivalenzrelation gegeben \treflexiv & symmetrie & transitiv gegeben");
        }
        else
        {
            Console.WriteLine("\nÄquivalenzrelation ist nicht gegeben \treflex oder symmetrie oder transitiv nicht gegeben");
        }
        if (reflexiv == true && antisymmetrie == true && Transitivität == true)
        {
            Console.WriteLine("\nDamit ist die Halbordnung (partielle Ordnung) gegeben\treflexiv & antisymmetrisch & transitiv gegeben");
        }
        else
        {
            Console.WriteLine("\nHalbordnung ist nicht gegeben \treflex oder antisymmetrie oder transitiv nicht gegeben");
        }
        return true;
    }

}