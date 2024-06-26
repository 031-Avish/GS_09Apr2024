﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class RequestSolution
    {
        [Key]
        public int SolutionId { get; set; }

        public int RequestId { get; set; }

        public Request RequestRaised { get; set; }

        public string SolutionDescription { get; set; }

        public int SolvedBy { get; set; }

        public Employee SolvedByEmployee { get; set; }

        public DateTime SolvedDate { get; set; }= DateTime.Now;
        public bool IsSolved { get; set; } = false;
        public string? RequestRaiserComment { get; set; }
        public ICollection<SolutionFeedback> Feedbacks { get; set; }

        public RequestSolution(int requestId, string solutionDescription, int solvedBy)
        {
            RequestId = requestId;
            SolutionDescription = solutionDescription;
            SolvedBy = solvedBy;
        }
        public override string ToString()
        {
            return $"\n**********************************\n" +
                $"Solution ID: {SolutionId}\n" +
                $"Request ID: {RequestId}\n" +
                $"Description: {SolutionDescription}" +
                $"\nSolved By: {SolvedBy}\n" +
                $"Is Solved: {IsSolved}\n" +
                $"Raiser Comment: {RequestRaiserComment ?? "N/A"}\n" +
                $"***************************************\n";
        }
    }
}
