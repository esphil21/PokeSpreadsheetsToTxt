using System;
using System.IO;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace PokeSpreadsheetsToTxt
{
    internal class Program
    {
        public static Dictionary<string, Pokemon> Pokedex = new Dictionary<string, Pokemon>();

        public static List<PokeOrigin> PokeOriginArr = new List<PokeOrigin>() { PokeOrigin.Null, PokeOrigin.Alolan,
            PokeOrigin.Alolan, PokeOrigin.Galarian, PokeOrigin.Hisuian, PokeOrigin.Hoennian, PokeOrigin.Johtonian,
            PokeOrigin.Kalosite, PokeOrigin.Kantonian, PokeOrigin.Liorian, PokeOrigin.Sinnoh };

        public static EnumMethods enumer = new EnumMethods();

        private static regices regi = new regices();
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var spreadsheet = new FileInfo(@"C:\Source\RMXP\Cobalt 0.2.4\CustomWork\PokeSpreadsheetsToTxt\Pokemon Cobalt Spreadsheet.xlsx");
            var oldtxt = new FileInfo(@"C:\Source\RMXP\Cobalt 0.2.4\CustomWork\PokeSpreadsheetsToTxt\PokeSpreadsheetsToTxt\bin\Debug\netcoreapp3.1\pokemon.txt");
            List<string> PKMNtxtLines = null;
            List<int> LineNum_O_DexNums = new List<int>();

            if (oldtxt.Exists)
            {
                PKMNtxtLines = new List<string>(File.ReadAllLines(oldtxt.FullName).ToList());



                for (int i = 0; i < PKMNtxtLines.Count; i++)
                {
                    string line = PKMNtxtLines[i];
                    var match = regi.DexNum.Match(line);
                    if (match.Success)
                    {
                        LineNum_O_DexNums.Add(i);
                    }
                }
            }

            if (spreadsheet.Exists)
            {
                using var package = new ExcelPackage(spreadsheet);
                var wb = package.Workbook;
                var NationalDex = package.Workbook.Worksheets[(int)SheetName.NationalDex];
                var MoveSets = package.Workbook.Worksheets[(int)SheetName.MoveSets];


                Pokemon newPoke = new Pokemon();
                for (int i = 2; i < 30; i++)
                {
                    newPoke = new Pokemon();
                    if(CreateAPokemon(ref newPoke, wb, i, PKMNtxtLines, LineNum_O_DexNums) && IsCompletePokemon(newPoke))
                    {
                        string internalName = newPoke.GetInternalName();
                        if (!Pokedex.ContainsKey(internalName))
                        {
                            Pokedex.Add(internalName, newPoke);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                UpdatePokemonTXT(Pokedex);
            }
        }


        /// <summary>
        /// Parse/Read data from the spreadsheet and from the pokemon.txt file (if there are any gaps in the data)
        /// </summary>
        /// <param name="_poke"></param>
        /// <param name="wb"></param>
        /// <param name="row"></param>
        /// <param name="oldtxt"></param>
        /// <param name="dexnums"></param>
        /// <returns></returns>
        private static bool CreateAPokemon(ref Pokemon _poke, ExcelWorkbook wb, int row, List<string> oldtxt, List<int> dexnums)
        {
            var NatDex = wb.Worksheets[(int)SheetName.NationalDex];
            var MoveSets = wb.Worksheets[(int)SheetName.MoveSets];
            var TM_Moves = wb.Worksheets[(int)SheetName.TM_Moves];
            var TR_Moves = wb.Worksheets[(int)SheetName.TR_Moves];
            var Tutor_Moves = wb.Worksheets[(int)SheetName.TutorMoves];
            var Evolutions = wb.Worksheets[(int)SheetName.EvolutionMethods];

            bool newPoke = false;

            int PKMNtxtLine = 0;
            // NUM
            if (int.TryParse(NatDex.GetValue(row, (int)NatDexCol.Num).ToString(), out int int_result) && !_poke.SetDexNumber(int_result))
            {
                Console.WriteLine($"Failed to SetDexNumber with data at row: {row}, col: {NatDexCol.Num}");
                return false;
            }
            PKMNtxtLine++;

            if(_poke.GetDexNumber() > 898)
            {
                newPoke = true;
            }


            // NAME
            if (!_poke.SetName(NatDex.GetValue(row, (int)NatDexCol.Pokemon_Name).ToString()))
            {
                Console.WriteLine($"Failed to SetName with data at row: {row}, col: {NatDexCol.Pokemon_Name}");
                return false;
            }
            PKMNtxtLine++;

            string pokeName = _poke.GetName();
            string regionalForm = pokeName.Substring(pokeName.LastIndexOf('-') + 1);

            if(enumer.IsA_(PokeOriginArr, regionalForm))
            {

            }



            // INTERNAL_NAME
            if (!_poke.SetInternalName(_poke.GetName().ToUpper()))
            {
                Console.WriteLine($"Failed to SetInternalName with {_poke.GetName().ToUpper()}");
                return false;
            }
            PKMNtxtLine++;


            // TYPE1
            var _type1 = NatDex.GetValue(row, (int)NatDexCol.Type1);
            if (_type1 != null && !_poke.SetType(0, _type1.ToString()))
            {
                Console.WriteLine($"Failed to SetType 1 to {NatDex.GetValue(row, (int)NatDexCol.Type1)}) for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;

            // TYPE2
            var _type2 = NatDex.GetValue(row, (int)NatDexCol.Type2);
            if (_type2 != null)
            {
                if(_type2.ToString() == "-----------")
                {
                    _type2 = "NULL";
                    PKMNtxtLine--;
                }
                if (!_poke.SetType(1, _type2.ToString()))
                {
                    Console.WriteLine($"Failed to SetType 2 to {NatDex.GetValue(row, (int)NatDexCol.Type2)}) for {_poke.GetInternalName()}");
                    return false;
                }
                PKMNtxtLine++;
            }


            // STATS
            int statCol = (int)NatDexCol.HP;
            for (int i = 0; i < Pokemon.NUM_STATS - 1; i++)
            {
                if(int.TryParse(NatDex.GetValue(row, statCol).ToString(), out int _stat))
                {
                    if(!_poke.SetStat(i, _stat))
                    {
                        Console.WriteLine($"Failed to SetStat({i} to {_stat}) for {_poke.GetInternalName()}");
                        return false;
                    }
                }
                statCol++;
            }
            PKMNtxtLine++;


            // GENDERRATE
            var genderrate = NatDex.GetValue(row, (int)NatDexCol.GenderRate);
            if (genderrate == null && !newPoke)    // then pull from oldtxt
            {
                string lineGenderRate = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                genderrate = lineGenderRate.Substring(lineGenderRate.IndexOf("=") + 2);
            }
            if (!_poke.SetGenderRate(genderrate.ToString()))
            {
                Console.WriteLine($"Failed to SetGenderRate for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // GROWTHRATE
            var growthrate = NatDex.GetValue(row, (int)NatDexCol.GrowthRate);
            if(growthrate == null && !newPoke)    // then pull from oldtxt
            {
                string lineGrowthRate = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                growthrate = lineGrowthRate.Substring(lineGrowthRate.IndexOf("=") + 2);
            }
            if (!_poke.SetGrowthRate(growthrate.ToString()))
            {
                Console.WriteLine($"Failed to SetGrowthRate for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;

            // BASE_EXP
            var baseexp = NatDex.GetValue(row, (int)NatDexCol.BaseEXP);
            if (baseexp == null && !newPoke)    // then pull from oldtxt
            {
                string lineBaseEXP = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                baseexp = lineBaseEXP.Substring(lineBaseEXP.IndexOf("=") + 2);
            }
            if (int.TryParse(baseexp.ToString(), out int_result) && !_poke.SetBaseEXP(int_result))
            {
                Console.WriteLine($"Failed to SetBaseEXP for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // EVs
            var ev = NatDex.GetValue(row, (int)NatDexCol.EffortPoints_TXT);
            if (ev == null && !newPoke)         // then pull from oldtxt
            {
                string lineEV = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                ev = lineEV.Substring(lineEV.IndexOf("=") + 2);
            }
            if (!_poke.SetEffortValues(ev.ToString()))
            {
                Console.WriteLine($"Failed to SetEffortValue({ev}) for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // RARENESS
            var rareness = NatDex.GetValue(row, (int)NatDexCol.Rareness);
            if (rareness == null && !newPoke)    // then pull from oldtxt
            {
                string lineRareness = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                rareness = lineRareness.Substring(lineRareness.IndexOf("=") + 2);
            }
            if (int.TryParse(rareness.ToString(), out int_result) && !_poke.SetRareness(int_result))
            {
                Console.WriteLine($"Failed to SetRareness for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // HAPPINESS
            var happiness = NatDex.GetValue(row, (int)NatDexCol.Happiness);
            if (happiness == null && !newPoke)    // then pull from oldtxt
            {
                string lineHappiness = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                happiness = lineHappiness.Substring(lineHappiness.IndexOf("=") + 2);
            }
            if (int.TryParse(happiness.ToString(), out int_result) && !_poke.SetHappiness(int_result))
            {
                Console.WriteLine($"Failed to SetHappiness for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // ABILITIES
            var _ability1 = NatDex.GetValue(row, (int)NatDexCol.Ability1);
            if (_ability1 != null && !_poke.SetAbility(0, _ability1.ToString()))
            {
                Console.WriteLine($"Failed to SetAbility 1 to {NatDex.GetValue(row, (int)NatDexCol.Ability1)}) for {_poke.GetInternalName()}");
                return false;
            }
            var _ability2 = NatDex.GetValue(row, (int)NatDexCol.Ability2);
            if (_ability2 != null)
            {
                if (!_poke.SetAbility(1, _ability2.ToString()))
                {
                    Console.WriteLine($"Failed to SetAbility 2 to {NatDex.GetValue(row, (int)NatDexCol.Ability2)}) for {_poke.GetInternalName()}");
                    return false;
                }
            }
            else
            {
                _poke.SetAbility(1, "");
            }
            PKMNtxtLine++;

            // HIDDENABILITY
            var _ha = NatDex.GetValue(row, (int)NatDexCol.HiddenAbility);
            if (_ha != null)
            {
                if (!_poke.SetAbility(2, _ha.ToString()))
                {
                    Console.WriteLine($"Failed to SetAbility HiddenAbility to {NatDex.GetValue(row, (int)NatDexCol.HiddenAbility)}) for {_poke.GetInternalName()}");
                    return false;
                }
                PKMNtxtLine++;
            }
            else
            {
                _poke.SetAbility(2, "");
            }


            // MOVES
            // LEARNSET
            var learnset = MoveSets.GetValue(row, (int)MoveSetsCol.LearnSet);
            if (learnset == null && !newPoke)    // then pull from oldtxt
            {
                string lineLearnSet = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                learnset = lineLearnSet.Substring(lineLearnSet.IndexOf("=") + 2);
            }
            if (!_poke.SetLearnMoves(learnset.ToString()))
            {
                Console.WriteLine($"Failed to SetLearnMoves for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // TM_MOVES updates a different file than pokemon.txt
            // TR_MOVES updates a different file than pokemon.txt


            // TUTOR_MOVES
            string tutoring = null; // TODO: update to pull from proper spreadsheet once its up to date.
            if (tutoring == null)    // then pull from oldtxt
            {
                string lineTutorMoves = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                if (lineTutorMoves.StartsWith("TutorMoves ="))
                {
                    tutoring = lineTutorMoves.Substring(lineTutorMoves.IndexOf("=") + 2);
                }
            }
            if (tutoring != null)   // Unable to extract EggMoves from oldTxt
            {
                if (!_poke.SetTutorMoves(tutoring.ToString()))
                {
                    Console.WriteLine($"Failed to SetTutorMoves for {_poke.GetInternalName()}");
                    return false;
                }
                PKMNtxtLine++;
            }
            else
            {
                _poke.SetTutorMoves("");  // Egg Moves remains empty
            }


            // EGG_MOVES
            var eggmoves = MoveSets.GetValue(row, (int)MoveSetsCol.EggMoves);
            if (eggmoves == null && !newPoke)    // then pull from oldtxt
            {
                string lineEggMoves = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                if (lineEggMoves.StartsWith("EggMoves ="))
                {
                    eggmoves = lineEggMoves.Substring(lineEggMoves.IndexOf("=") + 2);
                }
            }
            if (eggmoves != null)   // Unable to extract EggMoves from oldTxt
            {
                if(!_poke.SetEggMoves(eggmoves.ToString()))
                {
                    Console.WriteLine($"Failed to SetEggMoves for {_poke.GetInternalName()}");
                    return false;
                }
                PKMNtxtLine++;
            }
            else
            {
                _poke.SetEggMoves("");  // Egg Moves remains empty
            }


            // COMPATIBILITY
            int groupCol = (int)NatDexCol.EggGroup1;
            for (int i = 0; i < 2; i++)
            {
                var _group = NatDex.GetValue(row, groupCol);
                if (_group != null && !newPoke)
                {
                    if (!_poke.SetEggGroup(i, _group.ToString()))
                    {
                        Console.WriteLine($"Failed to SetEggGroup({i} to {NatDex.GetValue(row, groupCol)}) for {_poke.GetInternalName()}");
                        return false;
                    }
                }
                groupCol++;
            }
            PKMNtxtLine++;


            // STEPS_TO_HATCH
            var steps = NatDex.GetValue(row, (int)NatDexCol.StepsToHatch);
            if (steps == null && !newPoke)    // then pull from oldtxt
            {
                string lineSteps = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                steps = lineSteps.Substring(lineSteps.IndexOf("=") + 2);
            }
            if (int.TryParse(steps.ToString(), out int_result) && !_poke.SetStepsToHatch(int_result))
            {
                Console.WriteLine($"Failed to SetStepsToHatch for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // HEIGHT
            var height = NatDex.GetValue(row, (int)NatDexCol.Height);
            if (height == null && !newPoke)   // then pull from oldtxt
            {
                string lineHeight = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                height = lineHeight.Substring(lineHeight.IndexOf("=") + 2);
            }
            if (double.TryParse(height.ToString(), out double dbl_result) && !_poke.SetHeight(dbl_result))
            {
                Console.WriteLine($"Failed to SetHeight for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // WEIGHT
            var weight = NatDex.GetValue(row, (int)NatDexCol.Weight);
            if (weight == null && !newPoke)    // then pull from oldtxt
            {
                string lineWeight = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                weight = lineWeight.Substring(lineWeight.IndexOf("=") + 2);
            }
            if (double.TryParse(weight.ToString(), out dbl_result) && !_poke.SetWeight(dbl_result))
            {
                Console.WriteLine($"Failed to SetWeight for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // COLOR
            var color = NatDex.GetValue(row, (int)NatDexCol.Color);
            if (color == null && !newPoke)    // then pull from oldtxt
            {
                string lineColor = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                color = lineColor.Substring(lineColor.IndexOf("=") + 2);
            }
            if (!_poke.SetColor(color.ToString()))
            {
                Console.WriteLine($"Failed to SetColor for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // SHAPE
            var shape = NatDex.GetValue(row, (int)NatDexCol.Shape);
            if (shape == null && !newPoke)    // then pull from oldtxt
            {
                string lineShape = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                shape = lineShape.Substring(lineShape.IndexOf("=") + 2);
            }
            if (!_poke.SetShape(shape.ToString()))
            {
                Console.WriteLine($"Failed to SetShape for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // KIND
            var kind = NatDex.GetValue(row, (int)NatDexCol.Category);
            if (kind == null && !newPoke)    // then pull from oldtxt
            {
                string lineKind = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                kind = lineKind.Substring(lineKind.IndexOf("=") + 2);
            }
            if (!_poke.SetKind(kind.ToString()))
            {
                Console.WriteLine($"Failed to SetKind for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // POKEDEX
            var entry = NatDex.GetValue(row, (int)NatDexCol.DexEntry);
            if (entry == null && !newPoke)    // then pull from oldtxt
            {
                string lineEntry = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                entry = lineEntry.Substring(lineEntry.IndexOf("=") + 2);
            }
            if (!_poke.SetDexEntry(entry.ToString()))
            {
                Console.WriteLine($"Failed to SetDexEntry for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;


            // GENERATION
            var gen = NatDex.GetValue(row, (int)NatDexCol.Gen);
            if (gen == null && !newPoke)    // then pull from oldtxt
            {
                string lineGen = oldtxt[dexnums[row - 2] + PKMNtxtLine];
                gen = lineGen.Substring(lineGen.IndexOf("=") + 2);
            }
            if (int.TryParse(gen.ToString(), out int_result) && !_poke.SetGeneration(int_result))
            {
                Console.WriteLine($"Failed to SetGeneration for {_poke.GetInternalName()}");
                return false;
            }
            PKMNtxtLine++;

            #region POSITIONING
            // BattlerPlayerX
            string lineBPX = oldtxt[dexnums[row - 2] + PKMNtxtLine];
            string bpX = "";
            if (lineBPX.StartsWith("BattlerPlayerX ="))
            {
                bpX = lineBPX.Substring(lineBPX.IndexOf("=") + 2);
            }
            else
            {
                bpX = null;
            }
            if (bpX != null)
            {
                if (int.TryParse(bpX.ToString(), out int_result))
                {
                    _poke.SetBattlerPlayerX(int_result);
                    PKMNtxtLine++;
                }
            }

            // BattlerPlayerY
            string lineBPY = oldtxt[dexnums[row - 2] + PKMNtxtLine];
            string bpY = "";
            if (lineBPY.StartsWith("BattlerPlayerY ="))
            {
                bpY = lineBPY.Substring(lineBPY.IndexOf("=") + 2);
            }
            else
            {
                bpY = null;
            }
            if (bpY != null)
            {
                if (int.TryParse(bpY.ToString(), out int_result))
                {
                    _poke.SetBattlerPlayerY(int_result);
                    PKMNtxtLine++;
                }
            }

            // BattlerEnemyX
            string lineBEX = oldtxt[dexnums[row - 2] + PKMNtxtLine];
            string beX = "";
            if (lineBEX.StartsWith("BattlerEnemyX ="))
            {
                beX = lineBEX.Substring(lineBEX.IndexOf("=") + 2);
            }
            else
            {
                beX = null;
            }
            if (beX != null)
            {
                if (int.TryParse(beX.ToString(), out int_result))
                {
                    _poke.SetBattlerEnemyX(int_result);
                    PKMNtxtLine++;
                }
            }

            // BattlerEnemyY
            string lineBEY = oldtxt[dexnums[row - 2] + PKMNtxtLine];
            string beY = "";
            if (lineBEY.StartsWith("BattlerEnemyY ="))
            {
                beY = lineBEY.Substring(lineBEY.IndexOf("=") + 2);
            }
            else
            {
                beY = null;
            }
            if (beY != null)
            {
                if (int.TryParse(beY.ToString(), out int_result))
                {
                    _poke.SetBattlerEnemyY(int_result);
                    PKMNtxtLine++;
                }
            }

            // BattlerShadowX
            string lineBSX = oldtxt[dexnums[row - 2] + PKMNtxtLine];
            string bsX = "";
            if (lineBSX.StartsWith("BattlerShadowX ="))
            {
                bsX = lineBSX.Substring(lineBSX.IndexOf("=") + 2);
            }
            else
            {
                bsX = null;
            }
            if (bsX != null)
            {
                if (int.TryParse(bsX.ToString(), out int_result))
                {
                    _poke.SetBattlerShadowX(int_result);
                    PKMNtxtLine++;
                }
            }

            // BattlerShadowSize
            string lineBSSize = oldtxt[dexnums[row - 2] + PKMNtxtLine];
            string bsSize = "";
            if (lineBSSize.StartsWith("BattlerShadowSize ="))
            {
                bsSize = lineBSSize.Substring(lineBSSize.IndexOf("=") + 2);
            }
            else
            {
                bsSize = null;
            }
            if (bsSize != null)
            {
                if (int.TryParse(bsSize.ToString(), out int_result))
                {
                    _poke.SetBattlerShadowSize(int_result);
                    PKMNtxtLine++;
                }
            }
            #endregion POSITIONING

            // EVOLUTIONS
            string lineEvos = oldtxt[dexnums[row - 2] + PKMNtxtLine];
            string evos = "";
            if (lineEvos.StartsWith("Evolutions ="))
            {
                evos = lineEvos.Substring(lineEvos.IndexOf("=") + 2);
            }
            else
            {
                evos = "";
            }
            if (evos != null)
            {
                _poke.SetEvolutions(evos);
                PKMNtxtLine++;
            }

            #region EXTRAS
            // ALTERED
            var altered = NatDex.GetValue(row, (int)NatDexCol.Altered);
            if (altered == null)
            {
                _poke.SetAltered(false);
            }
            else
            {
                _poke.SetAltered(true);
            }

            // STARTER
            var starter = NatDex.GetValue(row, (int)NatDexCol.Starter);
            if(starter == null)
            {
                _poke.SetStarter(false);
            }
            else
            {
                _poke.SetStarter(true);
            }

            // GUARDIAN
            var guardian = NatDex.GetValue(row, (int)NatDexCol.Guardian);
            if (guardian == null)
            {
                _poke.SetGuardian(false);
            }
            else
            {
                _poke.SetGuardian(true);
            }

            // POSTGAME
            var postgame = NatDex.GetValue(row, (int)NatDexCol.PostGame);
            if (postgame == null)
            {
                _poke.SetPostGame(false);
            }
            else
            {
                _poke.SetPostGame(true);
            }
            #endregion EXTRAS

            return true;
        }

        /// <summary>
        /// All Pokemon must have a unique name, a dex number, at least 1 type, at least 1 ability and a set of stats greater than 0
        /// This methods checks all of these fields of _poke
        /// </summary>
        /// <param name="_poke"></param>
        /// <returns>True if all the above fields are filled in, otherwise returns false</returns>
        private static bool IsCompletePokemon(Pokemon _poke)
        {

            if(_poke.GetName() != null)
            {
                var _name = _poke.GetName();

                if (_poke.GetDexNumber() != null 
                    && _poke.GetDexNumber() != 0 
                    && _poke.GetAbility(0) != null 
                    && _poke.GetType(0) != null)  {

                    for (int i = 0; i < Pokemon.NUM_STATS; i++)
                    {
                        var _stat = _poke.GetStat(i);
                        if (_stat == null || _stat <= 0)
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Format and print out all data in _poke to the NewPokemon.txt and NewPokemonForms.txt
        /// </summary>
        /// <param name="_pokedex"></param>
        private static void UpdatePokemonTXT(Dictionary<string, Pokemon> _pokedex)
        {
            string newPKMNtxtPath = "././NewPokemon.txt";

            var newPKMNtxt = new FileInfo(newPKMNtxtPath);

            if (newPKMNtxt.Exists)
            {
                newPKMNtxt.Delete();
                var tempWriter = newPKMNtxt.AppendText();
                tempWriter.WriteLine($"" +
                    $"# This file was automatically populated by PokeSpreadsheetsToTxt.cs");
                tempWriter.Close();
            }

            foreach ( Pokemon poke in _pokedex.Values )
            {
                if (!IsCompletePokemon(poke) || poke == null || poke.GetName() == null)
                {
                    Console.WriteLine($"Incomplete Pokemon {poke.GetName()}");
                    return;
                }

                var writer = newPKMNtxt.AppendText();
                // NAMES
                writer.WriteLine($"" +
                    $"#-------------------------------" +
                    $"\n[{poke.GetDexNumber()}]" +
                    $"\nName = {poke.GetName()}" +
                    $"\nInternalName = {poke.GetInternalName()}");

                // TYPES
                writer.WriteLine($"Type1 = {poke.GetType(0)}");

                var secondType = poke.GetType(1);
                if (secondType != "Null")
                {
                    writer.WriteLine($"Type2 = {poke.GetType(1)}");
                }

                // STATS
                writer.Write($"BaseStats = ");
                for (int i = 0; i < Pokemon.NUM_STATS - 1; i++)
                {
                    writer.Write($"{poke.GetStat(i)}");
                    if (i < Pokemon.NUM_STATS - 2)
                    {
                        writer.Write(",");
                    }
                    else
                    {
                        writer.WriteLine();
                    }
                }

                writer.WriteLine($"GenderRate = {poke.GetGenderRate()}");

                writer.WriteLine($"GenderRate = {poke.GetGrowthRate()}");

                writer.WriteLine($"BaseEXP = {poke.GetBaseEXP()}");

                writer.WriteLine($"EffortPoints = {poke.GetEffortPoints(true)}");

                writer.WriteLine($"Rareness = {poke.GetRareness()}");

                writer.WriteLine($"Happiness = {poke.GetHappiness()}");

                // ABILITIES
                var abil1 = poke.GetAbility(0);
                writer.Write($"Abilities = {abil1}");
                var abil2 = poke.GetAbility(1);
                if (abil2 != nameof(PokeAbility.NULL))
                {
                    writer.Write($",{ abil2}");
                }
                writer.WriteLine();
                var hidabil = poke.GetAbility(2);
                if (hidabil != nameof(PokeAbility.NULL))
                {
                    writer.WriteLine($"HiddenAbility = {hidabil}");
                }

                writer.WriteLine($"Moves = {poke.GetLearnMoves()}");

                string tutoring = poke.GetTutorMoves();
                if (tutoring != "")
                    writer.WriteLine($"TutorMoves = {tutoring}");

                string eggmoves = poke.GetEggMoves();
                if (eggmoves != "")
                    writer.WriteLine($"EggMoves = {eggmoves}");

                writer.Write($"Compatibility = {poke.GetEggGroup(0)}");
                string group = poke.GetEggGroup(1);
                if (group != nameof(PokeEggGroup.NULL))
                {
                    writer.WriteLine($",{group}");
                }
                else
                {
                    writer.WriteLine();
                }

                writer.WriteLine($"StepsToHatch = {poke.GetStepsToHatch()}");

                writer.WriteLine($"Height = {poke.GetHeight()}");

                writer.WriteLine($"Weight = {poke.GetWeight()}");

                writer.WriteLine($"Color = {poke.GetColor()}");

                writer.WriteLine($"Shape = {poke.GetShape()}");

                writer.WriteLine($"Kind = {poke.GetKind()}");

                writer.WriteLine($"Pokedex = {poke.GetDexEntry()}");

                writer.WriteLine($"Generation = {poke.GetGeneration()}");

                int? bpx = poke.GetBattlerPlayerX();
                if (bpx != null)
                    writer.WriteLine($"BattlerPlayerX = {bpx}");

                int? bpy = poke.GetBattlerPlayerY();
                if (bpy != null)
                    writer.WriteLine($"BattlerPlayerY = {bpy}");

                int? bex = poke.GetBattlerEnemyX();
                if (bex != null)
                    writer.WriteLine($"BattlerEnemyX = {bex}");

                int? bey = poke.GetBattlerEnemyY();
                if (bey != null)
                    writer.WriteLine($"BattlerEnemyY = {bey}");

                int? bsx = poke.GetBattlerShadowX();
                if (bsx != null)
                    writer.WriteLine($"BattlerShadowX = {bsx}");

                int? bss = poke.GetBattlerShadowSize();
                if (bss != null)
                    writer.WriteLine($"BattlerShadowSize = {bss}");

                string evos = poke.GetEvolutions();
                if (evos != "")
                    writer.WriteLine($"Evolutions = {evos}");

                writer.Close();
            }

            var newPKMNtxtLines = new List<string>(File.ReadAllLines(newPKMNtxtPath).ToList());

            foreach (var line in newPKMNtxtLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
