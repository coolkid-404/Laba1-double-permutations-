using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lesson
{
    internal class Program
    {
        static string matrix_recovery(string closed, int[] readcol, int[] readline)
        {
            List<string> new_closed = new List<string>();
            int len_block = readline.Length;
            int maxValue = readline.Max();
            int lack = (readcol.Length * readline.Length) - closed.Length;
            int line_index = Array.IndexOf(readline, maxValue);
            int count = 0;
            List<int> incomplete_columns = readcol.OrderByDescending(x => x).Take(lack).ToList();

            foreach (int i in readcol)
            {
                if (incomplete_columns.Contains(i))
                {
                    if (closed.Length >= len_block)
                    {
                        new_closed.Add(closed.Substring(0, line_index - count) + "_" + closed.Substring(line_index - count, len_block - (line_index - count)));
                    }
                    else
                    {
                        new_closed.Add(closed);
                    }

                    closed = closed.Length >= len_block ? closed.Substring(len_block) : "";
                    count++;
                }
                else
                {
                    if (closed.Length >= len_block)
                    {
                        new_closed.Add(closed.Substring(0, len_block));
                    }
                    else
                    {
                        new_closed.Add(closed); 
                    }

                    closed = closed.Length >= len_block ? closed.Substring(len_block) : "";
                }
            }

            string closed_text = string.Join("", new_closed);
            return closed_text;
        }

        static void Main(string[] args)
        {
            string closed = "   ХРАИ НОВРЛЫОНАЬК Ж  Р ЕЛТЬПНЭЗЩВЖИИТТЕ СИ2 ЖНЖЫУЛЕД ЕВАВДСИМЫСАЛОАИАЦТ,ДЛ ЛЛТПКУН  АНТЗМ  НЛЮЕЕЯ ОККВОГТОЯДФАНЛС.УЯОТЕНСАН  ХИЬАЮККПАЫЯВТ Х ВКЕНР-ОЕВЛЬВОВЛОАИКНО ЦГМНДПХВИЛА,АИГТЙРЕНДООРРГЛ РАО ЙПЯДПЛВ Ш  М КФАИЛ,НВИ  ЧТНСМКИБОАЯЕОЭРО ЩРОАЖНГ ОЦОООАВИДДМЗОЕСЛИ К ЙПРИ ЕЬИ ЗРВЛ МТТОЛОЕОЕ ХЛВ БАЦЧЯЬО ЬВЭИР Ь ТИТЕАМП В ИЛТОШИНМЛ ЛРРЗ ЖЛИАЙ С И СБЛО Т ОЕВНИКАЫЕОВАХИН ЛБ АСИЧНЛ СЕЫОАУСБИКЖЕМОДОУИМРН НОКДЛНИСГЕИЮОАТ ИКАМЕОА ИЕ,5ОИУТЛНАРИС.ЛЛ,Н ФЛЕУА ДЬА АИК ЕАЛН.М ЖГАЕИДЯООЯЛС,ЛПИЫ АЗОЛИ ИНРЯН  МЕ.СВ  ОДЧЗ А АЛАОЗРТЕ ВМВАТ ЬЧК ЕЕННРЕТ ЮВПГ ТЛАГ МА ОНТЕРЕ ЯНООМИЧЕОЕДЕООАВЕГМТ.ЫСС  АОЬ ЫЕУ.ЬНЛШШЫА НИВУЕЕИА  ОСНИРГ ПДАИ ";
            int[] readcol = { 3, 5, 2, 0, 7, 8, 11, 1, 4, 9, 10, 12, 6 };
            int[] readline = { 19, 34, 28, 8, 7, 42, 36, 47, 23, 12, 2, 26, 6, 39, 3, 20, 21, 41, 22, 24, 31, 25, 9, 18, 17, 29, 11, 16, 45, 43, 14, 10, 1, 40, 44, 5, 0, 13, 35, 4, 38, 27, 33, 37, 46, 30, 15, 32 };

            int columns = readcol.Length;
            int lines = readline.Length;

            char[,] matrix = new char[lines, columns];

            int k = 0;

            closed = matrix_recovery(closed, readcol, readline);

            foreach (int i in readcol)
            {
                foreach (int j in readline)
                {
                    if (k < closed.Length) 
                    {
                        matrix[j, i] = closed[k];
                    }
                    else
                    {
                        matrix[j, i] = ' ';
                    }
                    k++;
                }
            }

            string Output_matrix = "";

            for (int i = 0; i < readline.Length; i++)
            {
                for (int j = 0; j < readcol.Length; j++)
                {
                    Output_matrix += matrix[i, j];
                }
            }

            Console.WriteLine(Output_matrix.Trim());


            Console.ReadLine();
        }

    }
}
