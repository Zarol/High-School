using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchMoneyMatch.Survey_Controls
{
    #region Primary Trait Enum
    /// <summary>
    /// List of the Primary Trait names
    /// The number the trait is assigned to correlates with its counter trait number in the Secondary Trait Enum
    /// </summary>
    public enum PrimaryTrait
    {
        optimistic = 0,
        workOriented = 1,
        arrogant = 2,
        teamPlayer = 3,
        oldFashioned = 4,
        writtenCommunication = 5,
        professional = 6,
        energetic = 7,
        focusOnOneTask = 8,
        leader = 9,
        creativeThinker = 10,
        emotionless = 11,
        dominant = 12,
        serious = 13,
        nonConformative = 14,
        trusting = 15,
        openToSharePersonalLife = 16,
        toleratesDisorder = 17,
        sensitive = 18,
        moral = 19,
        sticksToSchedule = 20,
        bigPicture = 21,
        officeSetting = 22,
        playItSafe = 23,
        internalizer = 24,
        roleAdaptable = 25,
        wideVarietyOfKnowledge = 26,
        actionOriented = 27,
        gutFeeling = 28,
        aggressive = 29,
        selfLearner = 30,
        personalResolver = 31,
        inspirer = 32,
        caseByCase = 33,
        purposeful = 34
    }
    #endregion
    #region Secondary Trait Enum
    /// <summary>
    /// List of the Secondary Trait names
    /// The number the trait is assigned to correlates with its counter trait number in the Primary Trait Enum
    /// </summary>
    public enum SecondaryTrait
    {
        critical = 0,
        familyOriented = 1,
        humble = 2,
        selfReliant = 3,
        experimenter = 4,
        oralCommunication = 5,
        personalized = 6,
        reserved = 7,
        multiTasker = 8,
        follower = 9,
        logical = 10,
        emotional = 11,
        submissive = 12,
        lively = 13,
        openToDiscussion = 14,
        skeptical = 15,
        workIsWork = 16,
        perfectionist = 17,
        unsentimental = 18,
        willingToBendRules = 19,
        thinkOnYourFeet = 20,
        smallDetails = 21,
        socialButterfly = 22,
        willingToTakeRisks = 23,
        externalizer = 24,
        roleUniform = 25,
        deepKnowledge = 26,
        thoughtOriented = 27,
        logicalDecision = 28,
        passive = 29,
        learnFromOthers = 30,
        justGetOverIt = 31,
        hardWorker = 32,
        broadRule = 33,
        needTheMoney = 34
    }
    #endregion
    #region Option Letter Enum
    /// <summary>
    /// If A: Primary Trait Weight = 3; Secondary Trait Weight = 0;
    /// If B: Primary Trait Weight = 2; Secondary Trait Weight = 1;
    /// If C: Primary Trait Weight = 1; Secondary Trait Weight = 2;
    /// If D: Primary Trait Weight = 0; Secondary Trait Weight = 3;
    /// </summary>
    public enum OptionLetter
    {
        A = 0,
        B = 1,
        C = 3,
        D = 4
    }
    #endregion


    public class Answer
    {
        private string strAnswerTitle;
        public string text { get { return strAnswerTitle; } }

        private PrimaryTrait primaryTrait;
        private SecondaryTrait secondaryTrait;
        private OptionLetter optionLetter;

        public Answer(string answerTitle, PrimaryTrait prim, SecondaryTrait sec, OptionLetter opt)
        {
            strAnswerTitle = answerTitle;
            primaryTrait = prim;
            secondaryTrait = sec;
            optionLetter = opt;
        }


    }
}
