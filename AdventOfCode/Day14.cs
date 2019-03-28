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
            private List<int> recipes;
            private Elf[] elfs;
            private int numRecipes;

            public Cookbook(int[] startRecipes)
            {
                if (startRecipes.Length != 2) {
                    throw new ArgumentException("Only works with exactly 2 starting elfs");
                }
                recipes = new List<int>();
                elfs = new Elf[2];
                for (int i = 0; i < startRecipes.Length; i++){
                    recipes.Add(startRecipes[i]);
                    elfs[i] = new Elf(recipes[i], i);
                }
                numRecipes = recipes.Count;
            }

            public string FindIdealRecipes(int numTrainingRecipes)
            {
                while (numRecipes < numTrainingRecipes+10)
                {
                    MakeHotChocolate();
                }
                var idealRecipes = recipes.Skip(numTrainingRecipes).Take(10);
                return string.Join("",idealRecipes);
            }

            public int RecipesNeededToMakeGoalRecipe(int[] goalRecipe)
            {
                int readHead = 0;
                int goalLength = goalRecipe.Length;
                for (int i = 0; i < 1000000000; i++)
                {
                    MakeHotChocolate();
                    for (; readHead < numRecipes-goalLength; readHead++){
                        for (int j = 0; j < goalLength; j++){
                            if (goalRecipe[j] != recipes[readHead+j])
                            {
                                break;
                            }
                            if (j==goalLength-1)
                            {
                                return readHead;
                            }
                        }
                    }
                }
                throw new Exception("Could not find goal recipe after making 1'000'000'000 recipes");
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
                    recipes.Add(newRecipe / 10);
                    // Should be safe as long as we only add two values <10, with a potential max of 18
                    recipes.Add(newRecipe - 10);
                    numRecipes += 2;
                } else{
                    recipes.Add(newRecipe);
                    numRecipes++;
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
            var cb = new Cookbook(new int[] { 3, 7 });
            return cb.FindIdealRecipes(recipesToMake);
        }

        public static int Puzzle2(string goalRecipe)
        {
            // Convert input to int array
            var goal = new int[goalRecipe.Length];
            for (int i = 0; i < goalRecipe.Length; i++)
            {
                goal[i] = goalRecipe[i] - '0';
            }

            var cb = new Cookbook(new int[] { 3, 7 });
            return cb.RecipesNeededToMakeGoalRecipe(goal);
        }
    }
}
