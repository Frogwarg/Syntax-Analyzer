using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OutputTree
{
    internal class Grammar
    {
        public static readonly Dictionary<string, List<string>> rules = new Dictionary<string, List<string>> {
            {"S",new List<string> { "a:=F;" }},
            {"F",new List<string> { "F+T", "T"}},
            {"T",new List<string> { "T*E", "T/E",  "E"}},
            {"E",new List<string> { "(F)", "-(F)", "a"}}
        };
        public static List<string> neTerm = new List<string> { "S", "F", "T", "E" };
        public static List<string> Term = new List<string> { "a", "+", "-", "/", "*", "(", ")", ":=", ";" };
        public string outputString = "";
        public Grammar() { }
        public Grammar(string str)
        {
            outputString = str;
        }
        public static string OutRules()
        {
            string pravila = "";
            foreach(string net in rules.Keys)
            {
                pravila += net+" -> ";
                foreach(string li in rules[net])
                {
                    pravila += li+" | ";
                }
                pravila= pravila.Remove(pravila.Length-2,1);
                pravila += Environment.NewLine;
            }
            return (pravila);
        }
        public void OutputLine()
        {
            Stack<string> stack = new Stack<string>();
            string copyStr = outputString;
            int counter = 0;
            //int reserveCouner = 0;
            //string reserveStr = "";
            stack.Push("S");
            while (true){
                if (rules.Keys.Contains(stack.Peek()))
                {

                    stack.Pop();
                }
                else
                {
                    if (stack.Peek() == copyStr[counter].ToString())
                    {
                        stack.Pop();
                        copyStr = copyStr.Remove(0, 1);
                    }
                }
                if (copyStr.Length == 0 || stack.Count == 0)
                {
                    break;
                }
            }
        }
        public string outString(ref TreeNode<string> tree, ref List<string> addings)
        {
            Stack<string> stack = new Stack<string>();
            Dictionary<int, Step> steps = new Dictionary<int, Step>();
            Dictionary<string, List<int>> usedProductions = new Dictionary<string, List<int>> {
                { "S",new List<int>()},
                { "F",new List<int>()},
                { "T",new List<int>()},
                { "E",new List<int>()},
            };
            List<List<Step>> fails = new List<List<Step>>();
            stack.Push("S");
            string copyStr = outputString;
            string resultStr = "S";
            string inStr = "S";
            int index = 0;
            int step = 0;
            string stars = "";
            bool getBack = false;
            bool bad = false;
            bool justJumped = false;
            int jumps = 0;
            int leksCounter = 0;
            while (stack.Count > 0 || index < copyStr.Length)
            {
                step++;
                steps.Add(step, new Step(step,CloneStack<string>(stack),index,resultStr,"",inStr,stars,CopyDictionary( usedProductions),addings)); /*шаги можно не удалять,
                                                                                                                           а при возврате на контр. точку
                                                                                                                           увеличивать значение шага на, 
                допустим (количество откатов)*1000. Количество откатов нужно отслеживать глобально в методе и хранить в переменной (jumps), наверное. При выборе одного из правил
                мы будем смотреть не только на то, есть ли оно в usedProductions, но также будем в списке steps искать (for (int i=step+1000;i<=jumps*1000;i+=1000)) шаги 
                (и считать их колчество и если их больше, чем правил у нетерминала, то возврат на шаг больше), таким образом проверяя все следы и у этого шага смотреть usedProductions. 
                                                                                                                            */
                if (stack.Count() == 0)
                {
                    getBack = true;
                }
                if (getBack || Term.Contains(stack.Peek())) //терминальный символ (маленькая буква)
                {
                    if (!getBack && (stack.Peek() == copyStr.Substring(index, stack.Peek().Length)))
                    {
                        index += stack.Peek().Length;
                        stack.Pop();
                        foreach (var pair in usedProductions)
                        {
                            usedProductions[pair.Key].Clear();
                        }
                    }
                    else
                    {
                        jumps++;
                        justJumped = true;
                        int back = getBack?2:1;
                        int reserved = FindBackPointsMax(steps)-back;
                        if (reserved >=0)
                        {
                            Step res= steps[reserved];
                            step = res.step;
                            stack = CloneStack<string>(res.stack);
                            index = res.stringIndex;
                            resultStr = res.outString;
                            inStr = res.innerResult;
                            int keyToRemoveAfter = step;
                            var keysToRemove = new List<int>();
                            fails.Add(new List<Step>());
                            addings = res.addings;
                            foreach (var pair in steps)
                                if (pair.Key > keyToRemoveAfter)
                                    keysToRemove.Add(pair.Key);
                            foreach (var key in keysToRemove)
                            {
                                fails[fails.Count - 1].Add(steps[key]);
                                //steps.Add(jumps*1000 + key, steps[key]);
                                steps.Remove(key);
                            } 
                            stars = res.stars;
                            usedProductions = res.usedProductions;
                            //if (Term.Contains(stack.Peek()))
                            //    continue;
                            if (neTerm.Contains(stack.Peek()) && usedProductions[stack.Peek()].Count== rules[stack.Peek()].Count)
                            {
                                getBack = true;
                            }
                            else
                            {
                                if (neTerm.Contains(stack.Peek()) && getBack)
                                {
                                    usedProductions[stack.Peek()].Add(usedProductions[stack.Peek()].Max() + 1);
                                }
                                getBack = false;
                            }
                            continue;
                        }else
                        {
                            bad = true;
                            break;
                        }
                    }
                }else if (neTerm.Contains(stack.Peek()))
                {
                    List<string> productions = rules[stack.Peek()];
                    string production = "";
                    if (productions.Count == 1)
                    {
                        production = productions[0];
                        usedProductions[stack.Peek()].Add(rules[stack.Peek()].IndexOf(production));
                    }
                    else
                    {
                        string result = "";
                        List<Step> failedSteps = findFailure(fails, steps[steps.Count - 1], jumps);
                        foreach(Step steping in failedSteps)
                        {
                            result += steping.step;
                        }
                        //MessageBox.Show(result);
                        stars += "*";
                        steps[step].backPoints += stars;
                        string current= copyStr[index].ToString();
                        string next = copyStr[index+1].ToString();
                        if (next != "a")
                        {
                            if (stack.Peek()=="T" && copyStr[index-1] == '+' && next=="+")
                            {
                                bad = true;
                                break;
                            }
                            foreach(string rule in rules[stack.Peek()])
                            {
                                if ((rule.Contains(next) && next!=")") || rule.Length == 1)
                                {
                                    if (!usedProductions[stack.Peek()].Contains(rules[stack.Peek()].IndexOf(rule)))
                                    {
                                        production = rule;
                                        usedProductions[stack.Peek()].Add(rules[stack.Peek()].IndexOf(production));
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                            
                        }
                        else
                        {
                            if (stack.Peek()=="E" && current=="-" && next != "(")
                            {
                                bad = true;
                                break;
                            }
                            if (stack.Peek()=="E" && current == "(")
                            {
                                production = rules[stack.Peek()][0];
                                usedProductions[stack.Peek()].Add(rules[stack.Peek()].IndexOf(production));
                            }
                            else
                            {
                                production = rules[stack.Peek()][rules[stack.Peek()].Count - 1]; //правилом устанавливаем последнее правило списка правил нетерминала из верхушки стека
                                if (production != "a" && usedProductions[stack.Peek()].Contains(rules[stack.Peek()].IndexOf(production))) //если это правило использовалось ранее, но к результату не привело
                                {
                                    for (int a = 0; a < rules[stack.Peek()].Count() - 1; a++) //проверяем, использовалось ли это правило ранее
                                    {
                                        if (!usedProductions[stack.Peek()].Contains(a)) //если в списке использованных правил нетерминала нет правила, то используем его
                                        {
                                            production = rules[stack.Peek()][a];
                                            usedProductions[stack.Peek()].Remove(rules[stack.Peek()].Count - 1);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    usedProductions[stack.Peek()].Add(rules[stack.Peek()].IndexOf(production));
                                }
                            }
                        }
                    }
                    if (production == "")
                    {
                        getBack = true;
                        if (usedProductions[stack.Peek()].Count == rules[stack.Peek()].Count)
                        {
                            bad = true;
                            break;
                        }
                        continue;
                    }
                    //else
                    //{
                    //    if (production == "a")
                    //    {
                    //        usedProductions[stack.Peek()].Add(rules[stack.Peek()].IndexOf(production));
                    //    }
                    //}
                    string poped=stack.Pop();
                    justJumped = false;
                    for (int i = production.Length - 1; i >= 0; i--) // добавляем символы правила в стек в обратном порядке
                    {
                        if (production[i] == '=' && production[i - 1] == ':')
                        {
                            stack.Push(":=");
                            i--;
                        }
                        else
                        {
                            stack.Push(production[i].ToString());
                        }
                    }
                    int k = inStr.IndexOf(poped);
                    if (k != -1)
                        inStr = inStr.Substring(0, k) + production + inStr.Substring(k + 1);
                    addings.Add(production);
                    resultStr += "=>" + inStr; //формируем строку вывода
                }
            }
            if (bad) {
                resultStr = "Строка не принята: "+resultStr;
            }
            return resultStr;
        }
        List<Step> findFailure(List<List<Step>> fails, Step curStep ,int jumps)
        {
            List<Step> result = new List<Step>();
            foreach (List<Step> trie in fails)
            {
                if (trie[0].step != curStep.step)
                {
                    result.Add(trie[0]);
                }
            }
            return result;
        }
        int FindBackPointsMin(Dictionary<int, Step> steps)
        {
            int minAsterisks = int.MaxValue;
            int maxKey = -1;
            foreach (var kvp in steps)
            {
                int asterisksCount = CountAsterisks(kvp.Value.backPoints);
                if (asterisksCount < minAsterisks)
                {
                    minAsterisks = asterisksCount;
                    maxKey = kvp.Key;
                }
            }
            return maxKey;
        }
        int FindBackPointsMax(Dictionary<int, Step> steps)
        {
            int maxAsterisks = -1;
            int maxKey = -1;
            foreach (var kvp in steps)
            {
                int asterisksCount = CountAsterisks(kvp.Value.backPoints);
                if (asterisksCount > maxAsterisks)
                {
                    maxAsterisks = asterisksCount; 
                    maxKey = kvp.Key;
                }
            }
            return maxKey;
        }
        int CountAsterisks(string str)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (c == '*')
                    count++;
            }
            return count;
        }
        static Stack<T> CloneStack<T>(Stack<T> original)
        {
            // Создаем временный массив для хранения элементов стека
            T[] tempArray = new T[original.Count];
            original.CopyTo(tempArray, 0);

            // Создаем новый стек и добавляем в него элементы из временного массива в обратном порядке
            Stack<T> newStack = new Stack<T>();
            for (int i = tempArray.Length - 1; i >= 0; i--)
            {
                newStack.Push(tempArray[i]);
            }

            return newStack;
        }
        static Dictionary<string, List<int>> CopyDictionary(Dictionary<string, List<int>> original)
        {
            return original.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.ToList()
            );
        }
        string outStack(Stack<string> stack)
        {
            string result = "";
            foreach (string str in stack.ToArray())
            {
                result += str + " ";
            }
            return result;
        }
    }
}
