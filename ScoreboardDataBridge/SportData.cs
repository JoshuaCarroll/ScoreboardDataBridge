using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardDataBridge
{
    public class SportData
    {
        public string GameClock;
        public string Period;
        public string PlayClock;
        public string ShotClock
        {
            get
            {
                return PlayClock;
            }
            set
            {
                PlayClock = value;
            }
        }
        public string Down;
        public string DistanceToFirstDown;
        public string BallOn;
        public TeamStats Home;
        public TeamStats Away;

        public SportData(string data, ScoreboardType scoreboardType, Sport sport)
        {
            Home = new TeamStats();
            Away = new TeamStats();

            switch (scoreboardType)
            {
                case ScoreboardType.Daktronics_AllSport:
                    GameClock = Extract(data, 1, 5);
                    Period = Extract(data, 142, 2); ;
                    PlayClock = Extract(data, 201, 8);
                    Home.Possession = Extract(data, 210, 1);
                    Home.Score = int.Parse(Extract(data, 108, 4));
                    Home.TeamName = Extract(data, 48, 20);
                    Home.Timeout = Extract(data, 132, 1);
                    Home.TimeOutsLeft = int.Parse(Extract(data, 122, 2));
                    Away.Score = int.Parse(Extract(data, 112, 4));
                    Away.TeamName = Extract(data, 68, 20);
                    Away.TimeOutsLeft = int.Parse(Extract(data, 130, 2));

                    switch (sport)
                    {
                        case Sport.Basketball:
                            Away.Possession = Extract(data, 216, 1);
                            Away.Timeout = Extract(data, 137, 1);
                            Home.Bonus = Extract(data, 222, 1);
                            Home.DoubleBonus = Extract(data, 223, 1);
                            Home.TeamFouls = int.Parse(Extract(data, 236, 2));
                            Away.Bonus = Extract(data, 229, 1);
                            Away.DoubleBonus = Extract(data, 230, 1);
                            Away.TeamFouls = int.Parse(Extract(data, 238, 2));
                            break;
                        case Sport.Football:
                            Away.Possession = Extract(data, 215, 1);
                            Away.Timeout = Extract(data, 124, 1);
                            Down = Extract(data, 222, 3);
                            DistanceToFirstDown = Extract(data, 225, 2);
                            BallOn = Extract(data, 220, 2);
                            break;
                        default:
                            break;
                    }

                    break;
                case ScoreboardType.Fairplay_MD70:
                case ScoreboardType.Fairplay_MD80:

                    break;
                default:
                    break;
            }
        }

        private string Extract(string Data, int Start, int Length)
        {
            return Data.Substring(Start - 1, Length).Trim();
        }
    }

    public enum ScoreboardType
    {
        Daktronics_AllSport,
        Fairplay_MD70,
        Fairplay_MD80
    }

    public enum Sport
    {
        Basketball,
        Football
    }
}
