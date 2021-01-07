using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AzBreak.AmazonMWS.Core.Internal
{
    public sealed class ParameterDictionaryBuilder
    {
        readonly Dictionary<string, object> parameters = new Dictionary<string, object>();

        public ParameterDictionaryBuilder Add(string memberName, object memberValue)
        {
            if (memberValue != null)
            {
                switch (memberValue)
                {
                    case IDictionary<string, object> memberParameters:
                        var membersDictionaryBuilder = new ParameterDictionaryBuilder();
                        foreach (var member in memberParameters)
                        {
                            membersDictionaryBuilder.Add(member.Key, member.Value);
                        }

                        var membersParameterQueryPart = QueryHelper.BuildCanonicalQueryString(membersDictionaryBuilder.parameters);
                        if (!string.IsNullOrEmpty(membersParameterQueryPart))
                            parameters.Add(memberName, membersParameterQueryPart);

                        break;
                    case IEnumerable<object> sequenceParameter:
                        foreach (var (value, index) in sequenceParameter.Select((value, index) => (value, index)))
                        {
                            var parameterKey = $"{memberName}.{index + 1}";
                            parameters.Add(parameterKey, value);
                        }
                        break;
                    default:
                        parameters.Add(memberName, memberValue);
                        break;
                }
            }

            return this;
        }

        public IDictionary<string, object> Parameters => parameters;
    }
}
