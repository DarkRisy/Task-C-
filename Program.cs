using System;
namespace pond_simulator
{
    class Program
    {
        static Fish Crucian()
        {
            var crucian = new Fish();
            crucian.massa = 0.2;
            crucian.max_massa = 3;
            crucian.age = 0;
            crucian.eat_fish = false;
            crucian.eat_food = true;
            crucian.count_food = 2;
            crucian.age_max = 600;
            crucian.days_without_food = 0;
            crucian.max_days_without_food = 240;
            return crucian;
        }
        static Fish Perch()
        {
            var perch = new Fish();
            perch.massa = 0.3;
            perch.max_massa = 5;
            perch.age = 1;
            perch.age_max = 500;
            perch.eat_fish = true;
            perch.eat_food = true;
            perch.count_food = 4;
            perch.mass_eaten_fish = perch.massa * 0.40;
            perch.days_without_food = 0;
            perch.max_days_without_food = 100;
            return perch;
        }
        static Fish Pike()
        {
            var pike = new Fish();
            pike.massa = 0.5;
            pike.max_massa = 8;
            pike.age = 1;
            pike.age_max = 550;
            pike.eat_fish = true;
            pike.eat_food = false;
            pike.days_without_food = 0;
            pike.max_days_without_food = 180;
            pike.mass_eaten_fish = pike.massa * 0.40;
            return pike;
        }
        static void Main()
        {

            var crucian = Crucian();
            var perch = Perch();
            var pike = Pike();
            // Pond pond = new Pond();
            Console.WriteLine("Запускаем мальков...");
            Console.Write("Введите количество карасей: ");
            while (!int.TryParse(Console.ReadLine(), out Pond.crucian) || Pond.crucian <= 0)
            {
                Console.Write("Неверный ввод! \nВведите количество карасей: ");
            }
            Console.Write("Введите количество окуней: ");
            while (!int.TryParse(Console.ReadLine(), out Pond.perch) || Pond.perch <= 0)
            {
                Console.Write("Неверный ввод! \nВведите количество окуней: ");
            }
            Console.Write("Введите количество щук: ");
            while (!int.TryParse(Console.ReadLine(), out Pond.pike) || Pond.pike <= 0)
            {
                Console.Write("Неверный ввод! \nВведите количество щук: ");
            }
            Pond.Statistic();
            Pond.max_biomass_fish = (crucian.max_massa * Pond.crucian) + (perch.max_massa * Pond.perch) + (pike.max_massa * Pond.pike);
            Pond.max_biomass_food = Pond.max_biomass_fish * 2;
            Pond.everyday_rise_food = Pond.max_biomass_food * 0.095;
            Pond.biomass_food = Pond.max_biomass_food;
            // Console.Write("Вес карасей: ");
            // Console.WriteLine("{0:0.000}", crucian.massa);
            // Console.WriteLine($"Возраст карасей: {crucian.age}");
            while (Pond.pike > 0 || Pond.perch > 0 || Pond.crucian > 0)
            {
                
                Pond.biomass_hunter = (perch.massa * Pond.perch) + (pike.massa * Pond.pike);
                Pond.biomass_crucian = (crucian.massa * Pond.crucian);
                Pond.amount_fish = Pond.crucian + Pond.pike + Pond.perch;
                Console.Write("Введите '+', для перехода на следующий день, или введите день на который хотите перейти: ");
                while (true)
                {
                    string input = Console.ReadLine();
                    int a;
                    bool b = Int32.TryParse(input, out a);
                    if (b == true && a > Pond.day)
                    {
                        Pond.day = a;
                        break; // обработка при успехе (почти всегда `break`)
                    }
                    if (b == false)
                    {
                        if (input == "+")
                        {
                            Pond.day += 1;
                            Console.WriteLine("Переход на следующий день");
                            break;
                        }
                        else
                        {
                            Console.Write("Неверный ввод! \nВведите '+', для перехода на следующий день, или введите день на который хотите перейти: ");
                        }
                    }
                    else
                    {
                        Console.Write("Неверный ввод! \nВведите '+', для перехода на следующий день, или введите день на который хотите перейти: ");
                    }
                }
                crucian.Eat();
                crucian.Age();
                crucian.Fisher();
                perch.Eat();
                perch.Age();
                perch.Fisher();
                pike.Eat();
                pike.Age();
                pike.Fisher();
                Pond.Statistic();
            }
            Console.WriteLine("THE END");
        }
    }

}



