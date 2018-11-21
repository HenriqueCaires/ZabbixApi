using Newtonsoft.Json;
using System.Collections.Generic;

namespace ZabbixApi.Entities
{
    public partial class Correlation : EntityBase
    {
        #region Properties
        /// <summary>
        /// (readonly) ID of the correlation.
        /// </summary>
        [JsonProperty("correlationid")]
        public override string Id { get; set; }

        /// <summary>
        /// Name of the correlation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the correlation.
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Whether the correlation is enabled or disabled. 
        /// 
        /// Possible values are: 
        /// 0 - (default) enabled; 
        /// 1 - disabled.
        /// </summary>
        public Status status { get; set; }
        #endregion

        #region Associations

        /// <summary>
        /// The correlation operation object defines an operation that will be performed when a correlation is executed. It has the following properties.
        /// </summary>
        public IList<Operation> operations { get; set; }

        /// <summary>
        /// The correlation filter object defines a set of conditions that must be met to perform the configured correlation operations. It has the following properties.
        /// </summary>
        public IList<Filter> filter { get; set; }
        

        #endregion

        #region ENUMS

        public enum Status
        {
            Enabled = 0,
            Disabled = 1
        }

        #endregion

        public class Operation
        {
            /// <summary>
            /// Type of operation. 
            /// 
            /// Possible values: 
            /// 0 - close old events; 
            /// 1 - close new event.
            /// </summary>
            public Type type { get; set; }

            public enum Type
            {
                CloseOldEvents = 0,
                CloseNewEvent = 1,
            }
        }

        public class Filter
        {
            /// <summary>
            /// Filter condition evaluation method. 
            /// 
            /// Possible values: 
            /// 0 - and/or; 
            /// 1 - and; 
            /// 2 - or; 
            /// 3 - custom expression
            /// </summary>
            public EvalType evaltype { get; set; }

            /// <summary>
            /// Set of filter conditions to use for filtering results.
            /// </summary>
            public IList<Condition> conditions { get; set; }

            /// <summary>
            /// (readonly) Generated expression that will be used for evaluating filter conditions. The expression contains IDs that reference specific filter conditions by its formulaid. The value of eval_formula is equal to the value of formula for filters with a custom expression.
            /// </summary>
            public string eval_formula { get; set; }

            /// <summary>
            /// User-defined expression to be used for evaluating conditions of filters with a custom expression. The expression must contain IDs that reference specific filter conditions by its formulaid. The IDs used in the expression must exactly match the ones defined in the filter conditions: no condition can remain unused or omitted.
            /// 
            /// Required for custom expression filters.
            /// </summary>
            public string formula { get; set; }

            public bool ShouldSerializeeval_formula() => false;


            public enum EvalType
            {
                AndOr = 0,
                And = 1,
                Or = 2,
                CustomExpression = 3,
            }

            public class Condition
            {
                /// <summary>
                /// Type of condition. 
                /// 
                /// Possible values: 
                /// 0 - old event tag; 
                /// 1 - new event tag; 
                /// 2 - new event host group; 
                /// 3 - event tag pair; 
                /// 4 - old event tag value; 
                /// 5 - new event tag value.
                /// </summary>
                public Type type { get; set; }

                /// <summary>
                /// Event tag (old or new). Required when type of condition is: 0, 1, 4, 5.
                /// </summary>
                public string tag { get; set; }

                /// <summary>
                /// Host group ID. Required when type of condition is: 2.
                /// </summary>
                public string groupid { get; set; }

                /// <summary>
                /// Old event tag. Required when type of condition is: 3.
                /// </summary>
                public string oldtag { get; set; }

                /// <summary>
                /// Old event tag. Required when type of condition is: 3.
                /// </summary>
                public string newtag { get; set; }

                /// <summary>
                /// Event tag (old or new) value. Required when type of condition is: 4, 5.
                /// </summary>
                public string value { get; set; }

                /// <summary>
                /// Arbitrary unique ID that is used to reference the condition from a custom expression. Can only contain capital-case letters. The ID must be defined by the user when modifying filter conditions, but will be generated anew when requesting them afterward.
                /// </summary>
                public string formulaid { get; set; }

                /// <summary>
                /// Condition operator. 
                /// 
                /// Required when type of condition is: 2, 4, 5.
                /// </summary>
                public ConditionOperator @operator { get; set; }

                public enum Type
                {
                    OldEventTag = 0,
                    NewEventTag = 1,
                    NewEventHostGroup = 2,
                    EventTagPair = 3,
                    OldEventTagValue = 4,
                    NewEventTagValue = 5,
                }
            }
        }
    }
}
