﻿using AdminView.Models;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminView.Assemblers
{
    public class PickAssembler
    {
        public static PickModel ConvertPickENtoModel(PickEN pickEN, int post)
        {
            PickModel pick = new PickModel();

            pick.Post = post;
            pick.Id = pickEN.Id;
            pick.Odd = pickEN.Odd;
            pick.Description = pickEN.Description;
            pick.PickResult = pickEN.PickResult;
            pick.Bookie = pickEN.Bookie;

            string PickType = pickEN.GetType().Name;

            switch(PickType)
            {
                case "ResultEN":
                    ResultEN resultEN = (ResultEN)pickEN;
                    pick.Type = "Result";
                    pick.Result = resultEN.Result;
                    pick.MatchTime = resultEN.Matchtime;
                    break;
                case "DoubleChanceEN":
                    DoubleChanceEN doubleChanceEN = (DoubleChanceEN)pickEN;
                    pick.Type = "Double chance";
                    pick.Result = doubleChanceEN.Result;
                    pick.MatchTime = doubleChanceEN.Matchtime;
                    pick.Result_b = doubleChanceEN.Result_b;
                    break;
                case "GoalEN":
                    GoalEN goalEN = (GoalEN)pickEN;
                    pick.Type = "Goal";
                    pick.Line = goalEN.Line;
                    pick.Quantity = goalEN.Quantity;
                    pick.Asian = goalEN.Asian;
                    break;
                case "HandicapEN":
                    HandicapEN handicapEN = (HandicapEN)pickEN;
                    pick.Type = "Handicap";
                    pick.Line = handicapEN.Line;
                    pick.Quantity = handicapEN.Quantity;
                    pick.Asian = handicapEN.Asian;
                    pick.HandicapResult = handicapEN.Result;
                    break;
                case "CorrectScoreEN":
                    CorrectScoreEN correctScorerEN = (CorrectScoreEN)pickEN;
                    pick.Type = "Correct score";
                    pick.HomeScore = correctScorerEN.HomeScore;
                    pick.AwayScore = correctScorerEN.AwayScore;
                    break;
                case "ScorerEN":
                    ScorerEN scorerEN = (ScorerEN)pickEN;
                    pick.Type = "Scorer";
                    pick.Scorer_name = scorerEN.Scorer_name;
                    pick.Scorer_Player = scorerEN.Player;
                    break;
                case "WincastEN":
                    WincastEN wincastEN = (WincastEN)pickEN;
                    pick.Type = "Wincast";
                    pick.Scorer_name = wincastEN.Scorer_name;
                    pick.Scorer_Player = wincastEN.Player;
                    pick.Team_name = wincastEN.Team_name;
                    break;
                case "TimeCastEN":
                    TimecastEN timecastEN = (TimecastEN)pickEN;
                    pick.Type = "Timecast";
                    pick.Scorer_name = timecastEN.Scorer_name;
                    pick.Scorer_Player = timecastEN.Player;
                    pick.Score_time = timecastEN.Score_time;
                    break;
            }

            return pick;
        }

        public static List<PickModel> ConvertPickENtoModel(IList<PickEN> picks, int post)
        {
            List<PickModel> picksModel = new List<PickModel>();
            foreach(PickEN pick in picks)
            {
                PickModel pickModel = PickAssembler.ConvertPickENtoModel(pick, post);
                picksModel.Add(pickModel);
            }

            return picksModel;
        }
    }
}