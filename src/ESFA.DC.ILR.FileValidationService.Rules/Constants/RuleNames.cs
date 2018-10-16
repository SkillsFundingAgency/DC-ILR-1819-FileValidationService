namespace ESFA.DC.ILR.FileValidationService.Rules.Constants
{
    public static class RuleNames
    {
        // Learner
        // Regex
        public const string FD_LearnRefNumber_AP = "FD_LearnRefNumber_AP";
        public const string FD_PrevLearnRefNumber_AP = "FD_PrevLearnRefNumber_AP";
        public const string FD_FamilyName_AP = "FD_FamilyName_AP";
        public const string FD_GivenNames_AP = "FD_GivenNames_AP";
        public const string FD_Sex_AP = "FD_Sex_AP";
        public const string FD_NINumber_AP = "FD_NINumber_AP";
        public const string FD_MathGrade_AP = "FD_MathGrade_AP";
        public const string FD_EngGrade_AP = "FD_EngGrade_AP";
        public const string FD_PostcodePrior_AP = "FD_PostcodePrior_AP";
        public const string FD_Postcode_AP = "FD_Postcode_AP";
        public const string FD_AddLine1_AP = "FD_AddLine1_AP";
        public const string FD_AddLine2_AP = "FD_AddLine2_AP";
        public const string FD_AddLine3_AP = "FD_AddLine3_AP";
        public const string FD_AddLine4_AP = "FD_AddLine4_AP";
        public const string FD_TelNo_AP = "FD_TelNo_AP";
        public const string FD_Email_AP = "FD_Email_AP";
        public const string FD_CampId_AP = "FD_CampId_AP";
        // Mandatory
        public const string FD_LearnRefNumber_MA = "FD_LearnRefNumber_MA";
        public const string FD_ULN_MA = "FD_ULN_MA";
        public const string FD_Ethnicity_MA = "FD_Ethnicity_MA";
        public const string FD_Sex_MA = "FD_Sex_MA";
        public const string FD_LLDDHealthProb_MA = "FD_LLDDHealthProb_MA";
        public const string FD_PostcodePrior_MA = "FD_PostcodePrior_MA";
        public const string FD_Postcode_MA = "FD_Postcode_MA";

        // Contact Preference
        // Regex
        public const string FD_ContPrefType_AP = "FD_ContPrefType_AP";
        // Mandatory
        public const string FD_ContPrefType_MA = "FD_ContPrefType_MA";
        public const string FD_ContPrefCode_MA = "FD_ContPrefCode_MA";

        // LLDD and Health Problem
        // Mandatory
        public const string FD_LLDDCat_MA = "FD_LLDDCat_MA";

        // Learner FAM
        // Regex
        public const string FD_LearnFAMType_AP = "FD_LearnFAMType_AP";
        // Mandatory
        public const string FD_LearnFAMType_MA = "FD_LearnFAMType_MA";
        public const string FD_LearnFAMCode_MA = "FD_LearnFAMCode_MA";

        // Provider Spec Learner Monitoring
        // Regex
        public const string FD_ProvSpecLearnMonOccur_AP = "FD_ProvSpecLearnMonOccur_AP";
        public const string FD_ProvSpecLearnMon_AP = "FD_ProvSpecLearnMon_AP";
        // Mandatory
        public const string FD_ProvSpecLearnMonOccur_MA = "FD_ProvSpecLearnMonOccur_MA";
        public const string FD_ProvSpecLearnMon_MA = "FD_ProvSpecLearnMon_MA";
        
        // Learner Employment Status
        // Regex
        public const string FD_AgreeId_AP = "FD_AgreeId_AP";
        // Mandatory
        public const string FD_EmpStat_MA = "FD_EmpStat_MA";
        public const string FD_DateEmpStatApp_MA = "FD_DateEmpStatApp_MA";

        // Employment Status Monitoring
        // Regex
        public const string FD_ESMType_AP = "FD_ESMType_AP";
        // Mandatory
        public const string FD_ESMType_MA = "FD_ESMType_MA";
        public const string FD_ESMCode_MA = "FD_ESMCode_MA";

        // Learner HE
        public const string FD_UCASPERID_AP = "FD_UCASPERID_AP";

        // Learner HE Financial Support
        // Mandatory
        public const string FD_FINTYPE_MA = "FD_FINTYPE_MA";
        public const string FD_FINAMOUNT_MA = "FD_FINAMOUNT_MA";

        // Learner Destination And Progression
        // Regex
        public const string FD_DP_LearnRefNumber_AP = "FD_DP_LearnRefNumber_AP";
        // Mandatory
        public const string FD_DP_LearnRefNumber_MA = "FD_DP_LearnRefNumber_MA";
        public const string FD_DP_ULN_MA = "FD_DP_ULN_MA";

        // DP Outcome
        // Regex
        public const string FD_DP_OutType_AP = "FD_DP_OutType_AP";
        // Mandatory
        public const string FD_DP_OutType_MA = "FD_DP_OutType_MA";
        public const string FD_DP_OutCode_MA = "FD_DP_OutCode_MA";
        public const string FD_DP_OutStartDate_MA = "FD_DP_OutStartDate_MA";
        public const string FD_DP_OutCollDate_MA = "FD_DP_OutCollDate_MA";
        
        // Learning Delivery
        // Regex
        public const string FD_LearnAimRef_AP = "FD_LearnAimRef_AP";
        public const string FD_DelLocPostCode_AP = "FD_DelLocPostCode_AP";
        public const string FD_ConRefNumber_AP = "FD_ConRefNumber_AP";
        public const string FD_EPAOrgID_AP = "FD_EPAOrgID_AP";
        public const string FD_OutGrade_AP = "FD_OutGrade_AP";
        public const string FD_SWSupAimId_AP = "FD_SWSupAimId_AP";
        // Mandatory
        public const string FD_LearnAimRef_MA = "FD_LearnAimRef_MA";
        public const string FD_AimType_MA = "FD_AimType_MA";
        public const string FD_AimSeqNumber_MA = "FD_AimSeqNumber_MA";
        public const string FD_LearnStartDate_MA = "FD_LearnStartDate_MA";
        public const string FD_LearnPlanEndDate_MA = "FD_LearnPlanEndDate_MA";
        public const string FD_FundModel_MA = "FD_FundModel_MA";
        public const string FD_DelLocPostCode_MA = "FD_DelLocPostCode_MA";
        public const string FD_CompStatus_MA = "FD_CompStatus_MA";
        
        // Learning Delivery FAM
        // Regex
        public const string FD_LearnDelFAMType_AP = "FD_LearnDelFAMType_AP";
        public const string FD_LearnDelFAMCode_AP = "FD_LearnDelFAMCode_AP";
        // Mandatory
        public const string FD_LearnDelFAMType_MA = "FD_LearnDelFAMType_MA";
        public const string FD_LearnDelFAMCode_MA = "FD_LearnDelFAMCode_MA";

        // Learning Delivery Work Placement
        // Mandatory
        public const string FD_WorkPlaceStartDate_MA = "FD_WorkPlaceStartDate_MA";
        public const string FD_WorkPlaceHours_MA = "FD_WorkPlaceHours_MA";
        public const string FD_WorkPlaceMode_MA = "FD_WorkPlaceMode_MA";

        // App Fin Record
        // Regex
        public const string FD_AFinType_AP = "FD_AFinType_AP";
        // Mandatory
        public const string FD_AFinType_MA = "FD_AFinType_MA";
        public const string FD_AFinCode_MA = "FD_AFinCode_MA";
        public const string FD_AFinDate_MA = "FD_AFinDate_MA";
        public const string FD_AFinAmount_MA = "FD_AFinAmount_MA";

        // Prov Spec Delivery Monitoring
        // Regex
        public const string FD_ProvSpecDelMonOccur_AP = "FD_ProvSpecDelMonOccur_AP";
        public const string FD_ProvSpecDelMon_AP = "FD_ProvSpecDelMon_AP";
        // Mandatory
        public const string FD_ProvSpecDelMonOccur_MA = "FD_ProvSpecDelMonOccur_MA";
        public const string FD_ProvSpecDelMon_MA = "FD_ProvSpecDelMon_MA";

        // Learning Delivery HE
        // Regex
        public const string FD_NUMHUS_AP = "FD_NUMHUS_AP";
        public const string FD_SSN_AP = "FD_SSN_AP";
        public const string FD_QUALENT3_AP = "FD_QUALENT3_AP";
        public const string FD_UCASAPPID_AP = "FD_UCASAPPID_AP";
        public const string FD_DOMICILE_AP = "FD_DOMICILE_AP";
        public const string FD_HEPostCode_AP = "FD_HEPostCode_AP";
        // Mandatory
        public const string FD_TYPEYR_MA = "FD_TYPEYR_MA";
        public const string FD_MODESTUD_MA = "FD_MODESTUD_MA";
        public const string FD_FUNDLEV_MA = "FD_FUNDLEV_MA";
        public const string FD_FUNDCOMP_MA = "FD_FUNDCOMP_MA";
        public const string FD_YEARSTU_MA = "FD_YEARSTU_MA";
        public const string FD_MSTUFEE_MA = "FD_MSTUFEE_MA";
        public const string FD_SPECFEE_MA = "FD_SPECFEE_MA";
    }
}
