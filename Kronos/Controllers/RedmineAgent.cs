using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Kronos.Models;
using Redmine.Net.Api;
using Redmine.Net.Api.Types;

namespace Kronos.Controllers;


class  RedmineAgent
{
    public static bool SubmitTime(EventModel commitEvent)
    {
        var client = new RedmineManager(host: "192.168.50.247:8080", apiKey: "ec6f3c68b3269670f013ca411879c6956a51b265", scheme: "http");

        client.ImpersonateUser = commitEvent.Author.Name;

        var parameter = new NameValueCollection {{RedmineKeys.INCLUDE,RedmineKeys.RELATIONS}};
        Regex rx = new Regex("[^#]*#(?'trackerid'[0-9]*) @(?'time'[a-zA-Z0-9]*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        MatchCollection matches = rx.Matches(input: commitEvent.Commit.Title);
        
        foreach (Match match in matches)
            try {
                GroupCollection groups = match.Groups;
                int IssueNo = int.Parse(groups["trackerid"].Value);
                string Hours = groups["time"].Value.ToString();
                TimeEntry timeEntry = new TimeEntry();
                timeEntry.Issue = IdentifiableName.Create<IdentifiableName>(IssueNo);
                timeEntry.Activity = IdentifiableName.Create<IdentifiableName>(4);
                timeEntry.Hours = DatetimeConversion.ConvertToDecimal(Hours);
                
                
                client.CreateObject(timeEntry) ;
                
            } catch (Exception ex)
            {
                Console.WriteLine();
                return false;
            }
            
        return true;
        
    }
        
}

    


