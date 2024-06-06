using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class SolutionFeedback
    {
        public SolutionFeedback(float rating, string remarks, int solutionId, int feedbackBy)
        {
            Rating = rating;
            Remarks = remarks;
            SolutionId = solutionId;
            FeedbackBy = feedbackBy;
        }


        [Key]
        public int FeedbackId { get; set; }
        public float Rating { get; set; }
        public string? Remarks { get; set; }
        public int SolutionId { get; set; }
        public RequestSolution Solution { get; set; }
        public int FeedbackBy { get; set; }
        public Employee FeedbackByEmployee { get; set; }
        public DateTime FeedbackDate { get; set; }= DateTime.Now;

        public override string ToString()
        {
            return $"\n*****************************************\n" +
                   $"Feedback ID: {FeedbackId}\n" +
                   $"Rating: {Rating}\n" +
                   $"Remarks: {(string.IsNullOrEmpty(Remarks) ? "No remarks" : Remarks)}\n" +
                   $"Solution ID: {SolutionId}\n" +
                   $"Feedback By: {FeedbackBy}\n" +
                   $"Feedback Date: {FeedbackDate}";
        }
    }
}
