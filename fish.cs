using System;
namespace pond_simulator
{
    public class Fish
    {
        public double massa;
        public double max_massa;
        public int age;
        public int fish_count;
        public int crucian;
        public int age_max;
        public bool eat_food;
        public bool eat_fish;
        public int days_without_food;
        public int max_days_without_food;
        public double mass_eaten_fish;
        public double count_food;
        public void Age()
        {
            age = Pond.day;
            if (age >= age_max)
            {
                Full_die();
            }
        }
        public void Eat()
        {
            if (eat_fish == true && mass_eaten_fish > Pond.biomass_crucian)
            {
                massa = (max_massa / age_max) * 0.1 * Pond.day;
                crucian -= 1;
            }
            if (eat_food == true && Pond.biomass_food > 0)
            {
                massa = (max_massa / age_max) * 0.1 * Pond.day;
                Pond.biomass_food = Pond.biomass_food + Pond.everyday_rise_food - count_food;
            }
            else
            {
                days_without_food += 1;
                if (days_without_food == max_days_without_food)
                {
                    Full_die();
                }
            }
        }
        public void Full_die()
        {
            {
                Pond.fish_died += fish_count + crucian;
                Pond.amount_fish -= fish_count + crucian;
                fish_count -= fish_count;
                crucian -= crucian;
            }
        }
        public void Die()
        {
            {
                Pond.fish_died += 1;
                Pond.amount_fish -= 1;
                fish_count -= 1;
                crucian -= 1;
            }
        }
        public void Fisher()
        {
            var random = new Random();
            for (int i = 0; i < 1; i++)
            {
                if (random.Next(2) == 1)
                {
                    Die();
                }
                break;
            }
        }

    }

}
