using System;
using System.Diagnostics.CodeAnalysis;

namespace Калькулятор
{
    class Program
    {
        static void Main(string[] args)
        {
            int schetchik=0;
            bool minus=false;
            bool k_k = true;
            bool k=true;
            bool really_plus= false;
            int n;
            int j;
            int i;
            string num_string_1;
            Console.Write("Введите первое число: ");
            num_string_1 = Console.ReadLine();
            char[] num_char_1 = num_string_1.ToCharArray();
            if(num_char_1[0]=='-')
            {
                minus = true;
                really_plus = true;
                for(i=0;i<num_char_1.Length-1;i++)
                {
                    num_char_1[i] = num_char_1[1 + i];
                }
                Array.Resize(ref num_char_1, num_char_1.Length - 1);
            }
            int[] num_1 = new int[num_char_1.Length];
            do
            {
                if (k_k == false)
                {
                    Console.Write("Введите повторно первое число: ");
                    num_string_1 = Console.ReadLine();
                    num_char_1 = num_string_1.ToCharArray();
                    num_1 = new int[num_char_1.Length];
                }
                k_k = true;
                for (i = 0; i < num_char_1.Length; i++)
                {
                    if (!int.TryParse(num_char_1[i].ToString(), out num_1[i]))
                        k_k = false;
                }
            }
            while (k_k == false);
            char selection;
            do
            {
                schetchik = 0;
                bool m = false;
                Console.Write("Выберите символ(+,-,*,/): ");
            while (!char.TryParse(Console.ReadLine(), out selection) || (selection != '+' && selection != '-' && selection != '*'))
            {
                Console.Write("\nВыберите символ(+,-,*) корректно: ");
            }
                switch (selection)
                {
                    case '+':

                        if (minus == true && really_plus == true)
                        {
                            really_plus = false;
                            goto case '-';
                        }
                        for (j = 0; j < num_1.Length; j++)
                        {
                            if (num_1[j] < 0 && selection == '+')
                            {
                                minus = true;
                                num_1[j] = num_1[j] * (-1);
                                goto case '-';
                            }
                        }
                        for (j = 0; j < num_1.Length; j++)
                        {
                            if (num_1[j] < 0)
                            {
                                num_1[j] = num_1[j] * (-1);
                            }
                        }
                        string num_string_2;
                        Console.Write("Введите второе число: ");
                        num_string_2 = Console.ReadLine();
                        char[] num_char_2 = num_string_2.ToCharArray();
                        int[] num_2 = new int[num_char_2.Length];
                        k = true;                       
                        do
                        {
                            if (k_k == false)
                            {
                                Console.Write("Введите повторно второе число: ");
                                num_string_2 = Console.ReadLine();
                                num_char_2 = num_string_2.ToCharArray();
                                num_2 = new int[num_char_2.Length];
                            }
                            k_k = true;
                            for (i = 0; i < num_char_2.Length; i++)
                            {
                                if (!int.TryParse(num_char_2[i].ToString(), out num_2[i]))
                                    k_k = false;
                            }
                        }
                        while (k_k == false);
                        if (num_1.Length >= num_2.Length)
                        {
                            m = false;
                            int[] sum = new int[num_1.Length + 1];
                            for (i = 0, j = 0; i < num_1.Length; i++, j++)
                            {
                                if (j < num_2.Length)
                                    sum[num_1.Length - i] += num_1[num_1.Length - 1 - i] + num_2[num_2.Length - 1 - j];
                                else
                                    sum[num_1.Length - i] += num_1[num_1.Length - 1 - i];

                                for (n = 0; n < num_1.Length; n++)
                                {
                                    while (sum[num_1.Length - n] >= 10)
                                    {
                                        sum[num_1.Length - 1 - n] += sum[num_1.Length - n] / 10;
                                        sum[num_1.Length - n] %= 10;
                                    }
                                }
                            }
                            Console.Write("Итог: ");
                            for (i = 0; i < sum.Length; i++)
                            {
                                if (sum[i] == 0 && m == false)
                                {
                                    schetchik++;
                                    continue;
                                }
                                if (sum[i] != 0 && m == false)
                                {
                                    m = true;
                                    if (minus == true)
                                    {
                                        sum[i] = sum[i] * (-1);
                                        minus = false;
                                    }
                                }                                
                            }
                            for (n = 0; n < schetchik; n++)
                            {
                                for (i = 0; i < sum.Length - 1; i++)
                                {
                                    sum[i] = sum[i + 1];
                                }
                            }
                            if (schetchik != sum.Length)
                            {
                                Array.Resize(ref sum, sum.Length - schetchik);
                            }
                            else
                            {
                                Array.Resize(ref sum, sum.Length - schetchik + 1);
                            }
                            for (i = 0; i < sum.Length; i++)
                            {
                                Console.Write(sum[i]);
                            }
                            Console.WriteLine();
                            num_1 = sum;
                            if (sum[0] < 0)
                            {
                                really_plus = true;
                                minus = true;
                            }
                            else
                            {
                                really_plus = false;
                                minus = false;
                            }
                        }
                        else
                        {
                            m = false;
                            int[] sum = new int[num_2.Length + 1];
                            for (i = 0, j = 0; j < num_2.Length; i++, j++)
                            {
                                if (i < num_1.Length)
                                    sum[num_2.Length - j] += num_1[num_1.Length - 1 - i] + num_2[num_2.Length - 1 - j];
                                else
                                    sum[num_2.Length - j] += num_2[num_2.Length - 1 - j];
                                for (n = 0; n < num_2.Length; n++)
                                {
                                    while (sum[num_2.Length - n] >= 10)
                                    {
                                        sum[num_2.Length - 1 - n] += sum[num_2.Length - n] / 10;
                                        sum[num_2.Length - n] %= 10;
                                    }
                                }
                            }
                            Console.Write("Итог: ");
                            for (j = 0; j < sum.Length; j++)
                            {
                                if (sum[j] == 0 && m == false)
                                {
                                    schetchik++;
                                    continue;
                                }
                                if (sum[j] != 0 && m == false)
                                {
                                    m = true;
                                    if (minus == true)
                                    {
                                        sum[j] = sum[j] * (-1);
                                        minus = false;
                                    }
                                }
                            }
                            for (n = 0; n < schetchik; n++)
                            {
                                for (i = 0; i < sum.Length - 1; i++)
                                {
                                    sum[i] = sum[i + 1];
                                }
                            }
                            if (schetchik != sum.Length)
                            {
                                Array.Resize(ref sum, sum.Length - schetchik);
                            }
                            else
                            {
                                Array.Resize(ref sum, sum.Length - schetchik + 1);
                            }
                            for (i = 0; i < sum.Length; i++)
                            {
                                Console.Write(sum[i]);
                            }
                            Console.WriteLine();
                            num_1 = sum;
                            if (sum[0] < 0)
                            {
                                really_plus = true;
                                minus = true;
                            }
                            else
                            {
                                really_plus = false;
                                minus = false;
                            }
                        }
                        break;
                    case '-':
                        if (selection == '-' && really_plus == true)
                        {
                            really_plus = false;
                            goto case '+';
                        }
                        for (j = 0; j < num_1.Length; j++)
                        {
                            if (num_1[j] < 0)
                            {
                                num_1[j] = num_1[j] * (-1);
                            }
                        }
                        Console.Write("Введите второе число: ");
                        num_string_2 = Console.ReadLine();
                        num_char_2 = num_string_2.ToCharArray();
                        num_2 = new int[num_char_2.Length];
                        k_k = true;
                        bool l = true;
                        k = true;
                        do
                        {
                            if (k_k == false)
                            {
                                Console.Write("Введите повторно второе число: ");
                                num_string_2 = Console.ReadLine();
                                num_char_2 = num_string_2.ToCharArray();
                                num_2 = new int[num_char_2.Length];
                            }
                            k_k = true;
                            for (i = 0; i < num_char_2.Length; i++)
                            {
                                if (!int.TryParse(num_char_2[i].ToString(), out num_2[i]))
                                    k_k = false;
                            }
                        }
                        while (k_k == false);
                        if (num_1.Length==num_2.Length )
                        { 
                           for(i=0;i<num_1.Length;i++)
                            {
                                if(l==true)
                                {
                                    if (num_1[i] < num_2[i])
                                        l = false;
                                    else
                                        l = true;
                                }
                            }
                        }
                        if (num_1.Length < num_2.Length)
                            l = false;
                        if(num_1.Length>=num_2.Length && l==true)
                        {
                            int[] sum = new int[num_1.Length];
                            for(j=0,i = 0; i < num_1.Length; i++,j++)
                            {
                                if (j < num_2.Length)
                                {
                                    if (num_1[num_1.Length - 1  - i] >= num_2[num_2.Length - 1 - j])
                                    {
                                        sum[num_1.Length - 1 - i] += num_1[num_1.Length - 1 - i] - num_2[num_2.Length - 1 - j];
                                    }
                                    else
                                    {
                                        num_1[num_1.Length - 2 - i] -= 1;
                                        num_1[num_1.Length - 1 - i] += 10;
                                        sum[num_1.Length - 1 - i] += num_1[num_1.Length - 1 - i] - num_2[num_2.Length - 1 - j];
                                    }
                                    for (n = 0; n < num_1.Length; n++)
                                    {
                                        while (num_1[num_1.Length - 1 - n] < 0)
                                        {
                                            num_1[num_1.Length - 2 - n] -= 1;
                                            num_1[num_1.Length - 1 - n] += 10;
                                        }
                                    }
                                }
                                else
                                {
                                    sum[num_1.Length - 1 - i] += num_1[num_1.Length - 1 - i];
                                }
                            }
                            Console.Write("Итог: ");
                            for (j = 0; j < sum.Length; j++)
                            {
                                if (sum[j] == 0 && m == false)
                                {
                                    schetchik++;
                                    continue;
                                }
                                if (sum[j] != 0 && m == false)
                                {
                                    m = true;
                                    if (minus == true)
                                    {
                                        sum[j] = sum[j] * (-1);
                                        minus = false;
                                    }
                                }
                            }
                            for (n = 0; n < schetchik; n++)
                            {
                                for (i = 0; i < sum.Length - 1; i++)
                                {
                                    sum[i] = sum[i + 1];
                                }
                            }
                            if (schetchik == sum.Length)
                            {
                                Array.Resize(ref sum, sum.Length - schetchik + 1);
                            }
                            else
                            {
                                Array.Resize(ref sum, sum.Length - schetchik);
                            }
                            for (i = 0; i < sum.Length; i++)
                            {
                                Console.Write(sum[i]);
                            }
                            Console.WriteLine();
                            num_1 = sum;
                            if (sum[0] < 0)
                            {
                                really_plus = true;
                                minus = true;
                            }
                            else
                            {
                                really_plus = false;
                                minus = false;
                            }
                        }
                        if(num_1.Length <= num_2.Length && l == false)
                        {
                            
                            int[] sum = new int[num_2.Length];
                            for (j = 0, i = 0; j < num_2.Length; i++, j++)
                            {
                                if (i < num_1.Length)
                                {
                                    if (num_2[num_2.Length - 1 - j]>=num_1[num_1.Length - 1 - i])
                                    {
                                        sum[num_2.Length-1 - j] += num_2[num_2.Length - 1 - j]- num_1[num_1.Length - 1 - i];
                                    }
                                    else
                                    {
                                        num_2[num_2.Length - 2 - j] -= 1;
                                        num_2[num_2.Length - 1 - j] += 10;
                                        sum[num_2.Length-1 - j] += num_2[num_2.Length - 1 - j]-num_1[num_1.Length - 1 - i];
                                    }
                                    for (n = 0; n < num_1.Length; n++)
                                    {
                                        while (num_2[num_2.Length - 1 - j] < 0)
                                        {
                                            num_2[num_2.Length - 2 - j] -= 1;
                                            num_2[num_2.Length - 1 - j] += 10;
                                        }
                                    }
                                    for (n = 0; n < num_2.Length; n++)
                                    {
                                        while (num_2[num_2.Length - 1 - n] < 0)
                                        {
                                            num_2[num_2.Length - 2 - n] -= 1;
                                            num_2[num_2.Length - 1 - n] += 10;
                                        }
                                    }
                                }
                                else
                                {
                                    sum[num_2.Length-1 - j] += num_2[num_2.Length - 1 - j];
                                }
                            }
                            Console.Write("Итог: ");
                            for (j = 0; j < sum.Length; j++)
                            {
                                if (sum[j] == 0 && m == false)
                                {
                                    schetchik++;
                                    continue;
                                }
                                if (sum[j] != 0 && m == false)
                                {
                                    m = true;
                                    sum[j] = sum[j] * (-1);
                                    if (minus== true)
                                    {
                                        sum[j] = sum[j] * (-1);
                                        minus = false;
                                    }
                                }
                            }
                            for (n = 0; n < schetchik; n++)
                            {
                                for (i = 0; i < sum.Length - 1; i++)
                                {
                                    sum[i] = sum[i + 1];
                                }
                            }
                            if (schetchik != sum.Length)
                            {
                                Array.Resize(ref sum, sum.Length - schetchik);
                            }
                            else
                            {
                                Array.Resize(ref sum, sum.Length - schetchik + 1);
                            }
                            for (i = 0; i < sum.Length; i++)
                            {
                                Console.Write(sum[i]);
                            }
                            Console.WriteLine();
                            num_1 = sum;
                            if (sum[0] < 0)
                            {
                                really_plus = true;
                                minus = true;
                            }
                            else
                            {
                                really_plus = false;
                                minus = false;
                            }
                        }
                        break;
                    case '*':
                        Console.Write("Введите второе число: ");
                        num_string_2 = Console.ReadLine();
                        num_char_2 = num_string_2.ToCharArray();
                        if (num_char_2[0] == '-' && minus == true)
                        {
                            minus = false;
                        }
                        else if (num_char_2[0] == '-' && minus == false)
                        {
                            minus = true;
                        }
                        if (num_char_2[0] == '-')
                        {
                            for (i = 0; i < num_char_2.Length - 1; i++)
                            {
                                num_char_2[i] = num_char_2[1 + i];
                            }
                        }
                        for(i = 0; i < num_1.Length; i++)
                        {
                            if (num_1[i] < 0)
                                num_1[i] = num_1[i] * (-1);
                        }
                        Array.Resize(ref num_char_2, num_char_2.Length - 1);
                        num_2 = new int[num_char_2.Length];
                        k_k = true;
                        k = true;
                        k = true;
                        do
                        {
                            if (k_k == false)
                            {
                                Console.Write("Введите повторно второе число: ");
                                num_string_2 = Console.ReadLine();
                                num_char_2 = num_string_2.ToCharArray();
                                num_2 = new int[num_char_2.Length];
                            }
                            k_k = true;
                            for (i = 0; i < num_char_2.Length; i++)
                            {
                                if (!int.TryParse(num_char_2[i].ToString(), out num_2[i]))
                                    k_k = false;
                            }
                        }
                        while (k_k == false);
                        if (num_1.Length >= num_2.Length)
                        {
                            int[] sum = new int[num_1.Length + num_2.Length];
                            for (j = 0; j < num_2.Length; j++)
                            {
                                for (i = 0; i < num_1.Length; i++)
                                {
                                    sum[num_1.Length + num_2.Length - 1 - i - j] += num_1[num_1.Length - 1 - i] * num_2[num_2.Length - 1 - j];

                                }
                                for (n = 0; n < num_1.Length + num_2.Length; n++)
                                {
                                    while (sum[num_1.Length + num_2.Length - 1 - n] >= 10)
                                    {
                                        sum[num_1.Length + num_2.Length - 2 - n] += sum[num_1.Length + num_2.Length - 1 - n] / 10;
                                        sum[num_1.Length + num_2.Length - 1 - n] %= 10;
                                    }
                                }
                            }
                            Console.Write("Итог: ");
                            for (i = 0; i < sum.Length; i++)
                            {
                                if (sum[i] == 0 && m == false)
                                {
                                    schetchik++;
                                    continue;
                                }
                                if (sum[i] != 0 && m == false)
                                {
                                    if (minus == true)
                                    {
                                        sum[i] = sum[i] * (-1);
                                        minus = false;
                                    }
                                }
                                m = true;
                            }
                            for (n = 0; n < schetchik; n++)
                            {
                                for (i = 0; i < sum.Length - 1; i++)
                                {
                                    sum[i] = sum[i + 1];
                                }
                            }
                            if (schetchik != sum.Length)
                            {
                                Array.Resize(ref sum, sum.Length - schetchik);
                            }
                            else
                            {
                                Array.Resize(ref sum, sum.Length - schetchik + 1);
                            }
                            for (i = 0; i < sum.Length; i++)
                            {
                                Console.Write(sum[i]);
                            }
                            Console.WriteLine();
                            num_1 = sum;
                            if (sum[0] < 0)
                            {
                                really_plus = true;
                                minus = true;
                            }
                            else
                            {
                                really_plus = false;
                                minus = false;
                            }
                        }
                        else
                        {
                            int[] sum = new int[num_1.Length + num_2.Length];
                            for (i = 0; i < num_1.Length; i++)
                            {
                                for (j = 0; j < num_2.Length; j++)
                                {
                                    sum[num_1.Length + num_2.Length - 1 - i - j] += num_1[num_1.Length - 1 - i] * num_2[num_2.Length - 1 - j];

                                }
                                for (n = 0; n < num_1.Length + num_2.Length; n++)
                                {
                                    while (sum[num_1.Length + num_2.Length - 1 - n] >= 10)
                                    {
                                        sum[num_1.Length + num_2.Length - 2 - n] += sum[num_1.Length + num_2.Length - 1 - n] / 10;
                                        sum[num_1.Length + num_2.Length - 1 - n] %= 10;
                                    }
                                }
                            }
                            Console.Write("Итог: ");
                            for (i = 0; i < sum.Length; i++)
                            {
                                if (sum[i] == 0 && m == false)
                                {
                                    schetchik++;
                                    continue;
                                }
                                if (sum[i] != 0 && m == false)
                                {
                                    if (minus == true)
                                    {
                                        sum[i] = sum[i] * (-1);
                                        minus = false;
                                    }
                                }
                                m = true;
                            }
                            for (n = 0; n < schetchik; n++)
                            {
                                for (i = 0; i < sum.Length - 1; i++)
                                {
                                    sum[i] = sum[i + 1];
                                }
                            }
                            if (schetchik != sum.Length)
                            {
                                Array.Resize(ref sum, sum.Length - schetchik);
                            }
                            else
                            {
                                Array.Resize(ref sum, sum.Length - schetchik + 1);
                            }
                            for (i = 0; i < sum.Length; i++)
                            {
                                Console.Write(sum[i]);
                            }
                            Console.WriteLine();
                            num_1 = sum;
                            if (sum[0] < 0)
                            {
                                really_plus = true;
                                minus = true;
                            }
                            else
                            {
                                really_plus = false;
                                minus = false;
                            }
                        }
                        break;
               }
                Console.Write("Продолжить/Нет(Y/C): ");
                char select;
                while(!char.TryParse(Console.ReadLine(), out select) || (select!='y' && select!='c' && select != 'Y' && select != 'C'))
                {
                    Console.Write("Введите корректно(Y/C): ");
                }
                if (select == 'y')
                    k = true;
                else if(select=='c')
                    k = false;
            }
            while (k == true);

        }
    }
}

