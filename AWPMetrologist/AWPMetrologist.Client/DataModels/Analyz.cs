using System;

namespace AWPMetrologist.Client.DataModels
{
    public class Analyz
    {
        public Analyz()
        {

        }

        public int Id { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime _toTime { get; set; }
        public int FaildObjectsInInterval { get; set; }
        public int FaildObjectCumulatively { get; set; }
        public double MTBF { get; set; }
        public int WorkableObjectAtTheBeginInterval { get; set; }
        public int WorkableObjectAtTheEndInterval { get; set; }
        public double AverageNumWorkableObject { get; set; }
        public double AverageFailureRate { get; set; }
        public double AverageProbabilityFailureObject { get; set; }
        public double AverageValueOfTheFailure { get; set; }
        public double MeanTimeBetweenFailure { get; set; }
    }
}
