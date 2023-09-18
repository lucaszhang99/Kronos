using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Kronos.Models;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;

namespace Kronos.Controllers
{
public class RedmineAgent
    {
        private readonly string redmineUrl;
        private readonly string redmineApiKey;
        private readonly RedmineManager client;

        public RedmineAgent(string redmineUrl, string redmineApiKey)
        {
            this.redmineUrl = redmineUrl;
            this.redmineApiKey = redmineApiKey;
            Console.WriteLine(redmineUrl);
            client = new RedmineManager(host: redmineUrl, apiKey: redmineApiKey, scheme: "https");
        }


        public bool SubmitTime(EventModel commitEvent)
        {

            client.ImpersonateUser = commitEvent.Author.Name;
            Console.WriteLine($"{commitEvent.Author.Name}");
            var parameter = new NameValueCollection { { RedmineKeys.INCLUDE, RedmineKeys.RELATIONS } };
            Regex rx = new Regex("[^#]*#(?'trackerid'[0-9]*) @(?'time'[a-zA-Z0-9]*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(input: commitEvent.Commit.Title);

            foreach (Match match in matches)
                try
                {
                    GroupCollection groups = match.Groups;
                    int IssueNo = int.Parse(groups["trackerid"].Value);
                    string Hours = groups["time"].Value.ToString();
                    TimeEntry timeEntry = new TimeEntry();
                    timeEntry.Issue = IdentifiableName.Create<IdentifiableName>(IssueNo);
                    timeEntry.Activity = IdentifiableName.Create<IdentifiableName>(159);
                    timeEntry.Hours = DatetimeConversion.ConvertToDecimal(Hours);

                    client.CreateObject(timeEntry);
                    Serilog.Log.Information("Sent #" + IssueNo.ToString() + "Hour " + Hours);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }

            return true;
        }
    }
}

