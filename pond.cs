using System;
namespace pond_simulator{
    public class Pond
    {
        public static double max_biomass_fish;
        public static double biomass_hunter;
        public static double biomass_crucian;
        public static int crucian;
        public static int perch;
        public static int pike;
        public static int amount_fish;
        public static double max_biomass_food;
        public static double biomass_food;
        public static double everyday_rise_food;
        public static int day;
        // public static string next_day;
        public static int fish_died;
        
        public static void Statistic()
        {
            if (biomass_food <= 0)
                {
                    biomass_food = 0;
                }
            Console.WriteLine($"________________День: {day}________________");
            Console.WriteLine($"Количество рыбы: {amount_fish}");
            Console.WriteLine($"Количество окуня: {perch}");
            Console.WriteLine($"Количество щуки: {pike}");
            Console.WriteLine($"Количество карася: {crucian}");
            Console.WriteLine($"Биомасса хищников: {biomass_hunter}");
            Console.WriteLine($"Биомасса карасей: {biomass_crucian}");
            Console.WriteLine($"Смерть рыб: {fish_died}");
            Console.WriteLine($"Биомасса корма: {biomass_food}");
            Console.WriteLine("______________Следующий день______________");
        }
}
}