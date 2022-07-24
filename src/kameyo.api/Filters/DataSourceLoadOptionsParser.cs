using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using System.Collections;

namespace Kameyo.Api.Filters
{
    public static class DataSourceLoadOptionsParser
    {


        public const string KEY_REQUIRE_TOTAL_COUNT = "requireTotalCount";

        public const string KEY_REQUIRE_GROUP_COUNT = "requireGroupCount";

        public const string KEY_IS_COUNT_QUERY = "isCountQuery";

        public const string KEY_SKIP = "skip";

        public const string KEY_TAKE = "take";

        public const string KEY_SORT = "sort";

        public const string KEY_GROUP = "group";

        public const string KEY_FILTER = "filter";

        public const string KEY_TOTAL_SUMMARY = "totalSummary";

        public const string KEY_GROUP_SUMMARY = "groupSummary";

        public const string KEY_SELECT = "select";

        public static void Parse(DataSourceLoadOptionsBase loadOptions, Func<string, string> valueSource)
        {
            string value = valueSource("requireTotalCount");
            string value2 = valueSource("requireGroupCount");
            string value3 = valueSource("isCountQuery");
            string value4 = valueSource("skip");
            string value5 = valueSource("take");
            string value6 = valueSource("sort");
            string value7 = valueSource("group");
            string value8 = valueSource("filter");
            string value9 = valueSource("totalSummary");
            string value10 = valueSource("groupSummary");
            string value11 = valueSource("select");
            if (!string.IsNullOrEmpty(value))
            {
                loadOptions.RequireTotalCount = Convert.ToBoolean(value);
            }

            if (!string.IsNullOrEmpty(value2))
            {
                loadOptions.RequireGroupCount = Convert.ToBoolean(value2);
            }

            if (!string.IsNullOrEmpty(value3))
            {
                loadOptions.IsCountQuery = Convert.ToBoolean(value3);
            }

            if (!string.IsNullOrEmpty(value4))
            {
                loadOptions.Skip = Convert.ToInt32(value4);
            }

            if (!string.IsNullOrEmpty(value5))
            {
                loadOptions.Take = Convert.ToInt32(value5);
            }

            if (!string.IsNullOrEmpty(value6))
            {
                loadOptions.Sort = JsonConvert.DeserializeObject<SortingInfo[]>(value6);
            }

            if (!string.IsNullOrEmpty(value7))
            {
                loadOptions.Group = JsonConvert.DeserializeObject<GroupingInfo[]>(value7);
            }

            if (!string.IsNullOrEmpty(value8))
            {
                loadOptions.Filter = JsonConvert.DeserializeObject<IList>(value8, new JsonSerializerSettings
                {
                    DateParseHandling = DateParseHandling.None
                });
            }

            if (!string.IsNullOrEmpty(value9))
            {
                loadOptions.TotalSummary = JsonConvert.DeserializeObject<SummaryInfo[]>(value9);
            }

            if (!string.IsNullOrEmpty(value10))
            {
                loadOptions.GroupSummary = JsonConvert.DeserializeObject<SummaryInfo[]>(value10);
            }

            if (!string.IsNullOrEmpty(value11))
            {
                loadOptions.Select = JsonConvert.DeserializeObject<string[]>(value11);
            }
        }
    }
}
