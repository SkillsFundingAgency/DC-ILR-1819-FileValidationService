using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.Model.Loose.Interface
{
    public interface ILooseLearner
    {
        string LearnRefNumber { get; }

        string PrevLearnRefNumber { get; }

        string FamilyName { get; }

        string GivenNames { get; }

        string Sex { get; }

        string NINumber { get; }

        string MathGrade { get; }

        string EngGrade { get; }

        string PostcodePrior { get; }

        string Postcode { get; }

        string AddLine1 { get; }

        string AddLine2 { get; }

        string AddLine3 { get; }

        string AddLine4 { get; }

        string TelNo { get; }

        string Email { get; }

        string CampId { get; }
    }
}
