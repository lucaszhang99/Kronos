using Kronos.Contract;

namespace Kronos.Models;

public class EventModel 
{
    public String EventName { get; }

    public Author Author { get; }

    public Commit Commit { get; }

    public EventModel(
        string eventName, 
        Author author, 
        Commit commit)
    {
        EventName = eventName;
        Author = author;
        Commit = commit;
    }
}



