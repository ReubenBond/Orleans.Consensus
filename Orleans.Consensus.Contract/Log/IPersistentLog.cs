namespace Orleans.Consensus.Contract.Log
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPersistentLog<TOperation>
    {
        IEnumerable<LogEntry<TOperation>> GetReverseCursor();

        LogEntryId LastLogEntryId { get; }

        LogEntry<TOperation> Get(long index);

        IEnumerable<LogEntry<TOperation>> GetCursor(long fromIndex);

        bool Contains(LogEntryId entryId);

        bool ConflictsWith(LogEntryId entryId);

        Task AppendOrOverwrite(LogEntry<TOperation> logEntry);
    }
}