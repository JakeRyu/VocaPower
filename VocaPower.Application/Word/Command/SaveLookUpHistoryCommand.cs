namespace VocaPower.Application.Word.Command
{
    public class SaveLookUpHistoryCommand
    {
        public string Word { get; set; }
        public string Definition { get; set; }

        public class Handler
        {
            public void Execute(SaveLookUpHistoryCommand command)
            {
                ILookUpHistoryRepository.Save(command.Word, command.Definition);
            }
        }
    }
}