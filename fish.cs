using System;
namespace pond_simulator
{
    public class Fish
    {
        public double massa;
        public double max_massa;
        public int age;
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
            if (eat_fish == true && mass_eaten_fish > Pond.biomass_crucian && Pond.pike > 0 || Pond.perch > 0 && Pond.crucian > 0)
            {
                if (Pond.crucian > 0)
                {
                    massa += (max_massa / age_max) * Pond.day;
                    Pond.crucian -= 1;
                    Pond.fish_died += 1;
                    Pond.amount_fish -= 1;
                }

            }
            if (eat_food == true && Pond.biomass_food > 0 || Pond.perch > 0 || Pond.crucian > 0)
            {
                massa += (max_massa / age_max) * Pond.day;
                if (Pond.biomass_food <= Pond.max_biomass_food)
                {
                    Pond.biomass_food += Pond.everyday_rise_food - count_food * (Pond.perch + Pond.crucian);
                }
                
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
                Pond.fish_died += Pond.perch + Pond.pike + Pond.crucian;
                Pond.amount_fish -= Pond.perch + Pond.pike + Pond.crucian;
                Pond.perch -= Pond.perch;
                Pond.pike -= Pond.pike;
                Pond.crucian -= Pond.crucian;
            }
        }
        public void Die()
        {
            {
                var random = new Random();
                for (int i = 0; i < 2; i++)
                {
                    if (Pond.crucian > 0 && random.Next(50) == 1)
                    {
                        Pond.fish_died += 1;
                        Pond.amount_fish -= 1;
                        Pond.crucian -= 1;
                        break;
                    }
                    if (Pond.perch > 0 && random.Next(50) == 2)
                    {
                        Pond.fish_died += 1;
                        Pond.amount_fish -= 1;
                        Pond.perch -= 1;
                        break;
                    }
                    if (Pond.pike > 0 && random.Next(50) == 3)
                    {
                        Pond.fish_died += 1;
                        Pond.amount_fish -= 1;
                        Pond.pike -= 1;
                        break;
                    }

                }

            }
        }
        public void Fisher()
        {

            Die();

        }

    }

}
