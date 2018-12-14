using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day14
    {
        public class Elf
        {
            public int Recipe;
            public int Pos;

            public Elf(int startRecipe, int startPos)
            {
                Recipe = startRecipe;
                Pos = startPos;
            }
        }

        public class Cookbook
        {
            private int[] recipes;
            private int numRecipes;
            private int trainingRecipes;
            private Elf[] elfs;
            
            public Cookbook(int[] startRecipes, int numTrainingRecipes)
            {
                numRecipes = startRecipes.Length;
                if (numRecipes != 2) {
                    throw new ArgumentException("Only works with exactly 2 starting elfs");
                }
                trainingRecipes = numTrainingRecipes;
                // Need room for all training recipes + the 10 goal recipes + 1 potential overflow
                recipes = new int[numTrainingRecipes + 10 + 1];
                elfs = new Elf[numRecipes];
                for (int i = 0; i < numRecipes; i++){
                    recipes[i] = startRecipes[i];
                    elfs[i] = new Elf(recipes[i], i);
                }
            }

            public string FindIdealRecipes()
            {
                while (numRecipes < trainingRecipes+10)
                {
                    MakeHotChocolate();
                }
                var idealRecipes = recipes.Skip(trainingRecipes).Take(10);
                return string.Join("",idealRecipes);
            }

            private void MakeHotChocolate()
            {
                // Find new recipe
                var newRecipe = 0;
                foreach (var elf in elfs){
                    newRecipe += elf.Recipe;
                }
                // Add to cookbook
                if (newRecipe >= 10)
                {
                    recipes[numRecipes++] = newRecipe / 10;
                    // Should be safe as long as we only add two values <10, with a potential max of 18
                    recipes[numRecipes++] = newRecipe - 10;
                } else{
                    recipes[numRecipes++] = newRecipe;
                }
                // Move elfs
                foreach (var elf in elfs){
                    elf.Pos = (elf.Pos + elf.Recipe + 1) % numRecipes;
                    elf.Recipe = recipes[elf.Pos];
                }
            }
        }


        public static string Puzzle1(int recipesToMake)
        {
            var cb = new Cookbook(new int[] { 3, 7 }, recipesToMake);
            return cb.FindIdealRecipes();
        }
    }
}
