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
            crucian.crucian = 0;
            crucian.age = 0;
            crucian.eat_fish = false;
            crucian.eat_food = true;
            crucian.count_food = 15;
            crucian.age_max = 600;
            crucian.days_without_food = 0;
            crucian.max_days_without_food = 240;
            return crucian;
        }
        static Fish Perch()
        {
            var perch = new Fish();
            perch.massa = 0.2;
            perch.max_massa = 5;
            perch.fish_count = 0;
            perch.age = 1;
            perch.age_max = 500;
            perch.eat_fish = true;
            perch.eat_food = true;
            perch.count_food = 15;
            perch.mass_eaten_fish = perch.massa * 0.40;
            perch.days_without_food = 0;
            perch.max_days_without_food = 100;
            return perch;
        }
        static Fish Pike()
        {
            var pike = new Fish();
            pike.massa = 0.42;
            pike.max_massa = 8;
            pike.fish_count = 0;
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
            while (!int.TryParse(Console.ReadLine(), out crucian.crucian) || crucian.crucian <= 0)
            {
                Console.Write("Неверный ввод! \nВведите количество карасей: ");
            }
            Console.Write("Введите количество окуней: ");
            while (!int.TryParse(Console.ReadLine(), out perch.fish_count) || perch.fish_count <= 0)
            {
                Console.Write("Неверный ввод! \nВведите количество окуней: ");
            }
            Console.Write("Введите количество щук: ");
            while (!int.TryParse(Console.ReadLine(), out pike.fish_count) || pike.fish_count <= 0)
            {
                Console.Write("Неверный ввод! \nВведите количество щук: ");
            }
            Pond.Statistic();
            // Console.Write("Вес карасей: ");
            // Console.WriteLine("{0:0.000}", crucian.massa);
            // Console.WriteLine($"Возраст карасей: {crucian.age}");
            while (true)
            {
                Pond.max_biomass_fish = (crucian.max_massa * crucian.crucian) + (perch.max_massa * perch.fish_count) + (pike.max_massa * pike.fish_count);
                Pond.biomass_hunter = (perch.massa * perch.fish_count) + (pike.massa * pike.fish_count);
                Pond.biomass_crucian = (crucian.massa * crucian.crucian);
                Pond.amount_fish = crucian.crucian + pike.fish_count + perch.fish_count;
                if (crucian.crucian >= 0)
                {
                    Pond.crucian = 0;
                }
                if (perch.fish_count >= 0)
                {
                    Pond.perch = 0;
                }
                if (pike.fish_count >= 0)
                {
                    Pond.pike = 0;
                }
                Pond.crucian = crucian.crucian;
                Pond.perch = perch.fish_count;
                Pond.pike =  pike.fish_count; 
                
                Pond.max_biomass_food = Pond.max_biomass_fish * 2 / 3;
                Pond.biomass_food = Pond.max_biomass_food;
                Pond.everyday_rise_food = Pond.max_biomass_fish * 0.05;
                Console.Write("Введите '+', для перехода на следующий день, или введите день на который хотите перейти: ");
                while (true)
                {
                    string input = Console.ReadLine();
                    int a;
                    bool b = Int32.TryParse(input, out a);
                    if (b == true)
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
        }
    }

}



