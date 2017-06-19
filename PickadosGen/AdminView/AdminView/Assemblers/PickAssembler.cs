using AdminView.Models;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminView.Assemblers
{
    public class PickAssembler
    {
        public static PickModel ConvertPickENtoModel(PickEN pickEN)
        {
            PickModel pick = new PickModel();

            pick.Id = pickEN.Id;
            pick.Odd = pickEN.Odd;
            pick.Description = pickEN.Description;
            pick.PickResult = pickEN.PickResult;
            pick.Bookie = pickEN.Bookie;

            string PickType = pickEN.GetType().Name;

            switch(PickType)
            {
                case "Result":
                    ResultEN resultEN = (ResultEN)pickEN;
                    pick.Result = resultEN.Result;
                    pick.MatchTime = resultEN.Matchtime;
                    break;
                case "DoubleChance":
                    DoubleChanceEN doubleChanceEN = (DoubleChanceEN)pickEN;
                    pick.Result = doubleChanceEN.Result;
                    pick.MatchTime = doubleChanceEN.Matchtime;
                    pick.Result_b = doubleChanceEN.Result_b;
                    break;
                case "Goal":
                    GoalEN goalEN = (GoalEN)pickEN;
                    pick.Line = goalEN.Line;
                    pick.Quantity = goalEN.Quantity;
                    pick.Asian = goalEN.Asian;
                    break;
                case "Handicap":
                    HandicapEN handicapEN = (HandicapEN)pickEN;
                    pick.Line = handicapEN.Line;
                    pick.Quantity = handicapEN.Quantity;
                    pick.Asian = handicapEN.Asian;
                    pick.HandicapResult = handicapEN.Result;
                    break;
                case "CorrectScore":
                    CorrectScoreEN correctScorerEN = (CorrectScoreEN)pickEN;
                    pick.HomeScore = correctScorerEN.HomeScore;
                    pick.AwayScore = correctScorerEN.AwayScore;
                    break;
                case "Scorer":
                    ScorerEN scorerEN = (ScorerEN)pickEN;
                    pick.Scorer_name = scorerEN.Scorer_name;
                    pick.Scorer_Player = scorerEN.Player;
                    break;
                case "Wincast":
                    WincastEN wincastEN = (WincastEN)pickEN;
                    pick.Scorer_name = wincastEN.Scorer_name;
                    pick.Scorer_Player = wincastEN.Player;
                    pick.Team_name = wincastEN.Team_name;
                    break;
                case "TimeCast":
                    TimecastEN timecastEN = (TimecastEN)pickEN;
                    pick.Scorer_name = timecastEN.Scorer_name;
                    pick.Scorer_Player = timecastEN.Player;
                    pick.Score_time = timecastEN.Score_time;
                    break;
            }

            return pick;
        }

        public static List<PickModel> ConvertPickENtoModel(IList<PickEN> picks)
        {
            List<PickModel> picksModel = new List<PickModel>();
            foreach(PickEN pick in picks)
            {
                PickModel pickModel = PickAssembler.ConvertPickENtoModel(pick);
                picksModel.Add(pickModel);
            }

            return picksModel;
        }
    }
}