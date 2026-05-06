using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindShaulsTreasure.Models
{
    public enum QuestType { Manual, Automatic }

    public class QuestInfo
    {
        /// <summary>
        /// The name of the quest.
        /// </summary>
        public string QuestName { get; set; }

        /// <summary>
        /// The hint for the quest.
        /// </summary>
        public string QuestHint { get; set; }

        /// <summary>
        /// The answer for the quest (Used only if <b>QuestType</b> is <b>Manual</b>).
        /// </summary>
        public string QuestAnswer { get; set; }

        //public required string LocationHint { get; set; }
        //public required string QuestLocation { get; set; }

        /// <summary>
        /// The type of the quest.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///   <item>
        ///     <see cref="QuestType.Manual"/> – The user inputs an answer to continue.
        ///   </item>
        ///   <item>
        ///     <see cref="QuestType.Automatic"/> – The quest signals when the user can continue.
        ///   </item>
        /// </list>
        /// </remarks>
        public QuestType QuestType { get; set; }

        /// <summary>
        /// The status of the quest (Used only if <b>QuestType</b> is <b>Automatic</b>).
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        ///   <item>
        ///     <b>True</b> – The user has succeeded and we can move to next quest. 
        ///   </item>
        ///   <item>
        ///     <b>False</b> – The user has not succeeded yet.
        ///   </item>
        /// </list>
        /// </remarks>
        public bool QuestSuccess { get; set; }

        /// <summary>
        /// The percentage of the score to award the user (Used only if <b>QuestType</b> is <b>Automatic</b>).
        /// </summary>
        public double ScorePercent { get; set; }

        /// <summary>
        /// Creates a new <see cref="QuestInfo"/> instance.
        /// </summary>
        /// <param name="QuestName">
        /// The name of the quest.
        /// </param>
        /// <param name="QuestHint">
        /// A hint shown to the user for completing the quest.
        /// </param>
        /// <param name="QuestType">
        /// The type of the quest (<see cref="QuestType.Manual"/> or <see cref="QuestType.Automatic"/>).
        /// </param>
        /// <param name="QuestAnswer">
        /// The correct answer for the quest.
        /// Used only when <see cref="QuestType"/> is <see cref="QuestType.Manual"/>.
        /// Defaults to an empty string.
        /// </param>
        /// <remarks>
        /// <list type="bullet">
        ///   <item>
        ///     <b>Manual</b> – <see cref="QuestAnswer"/> is required to validate user input.
        ///   </item>
        ///   <item>
        ///     <b>Automatic</b> – <see cref="QuestSuccess"/> is initialized to <b>false</b>
        ///     and <see cref="ScorePercent"/> defaults to <b>100</b>.
        ///   </item>
        /// </list>
        /// </remarks>
        public QuestInfo(
            string QuestName,
            string QuestHint,
            QuestType QuestType,
            string QuestAnswer = ""
            )
        {
            this.QuestName = QuestName;
            this.QuestHint = QuestHint;
            this.QuestType = QuestType;
            this.QuestAnswer = QuestAnswer;

            this.QuestSuccess = false;
            this.ScorePercent = 100;
        }
    }
}
