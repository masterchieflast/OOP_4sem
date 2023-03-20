using System.Windows.Input;

namespace Lab04_05;

public class CustomCommand
{
    private static RoutedUICommand _saveCommand;
    private static RoutedUICommand _loadCommand;
    private static RoutedUICommand _searchCommand;
    private static RoutedUICommand _deleteCommand;
    private static RoutedUICommand _updateCommand;
    private static RoutedUICommand _addCommand;
    private static RoutedUICommand _undoCommand;
    private static RoutedUICommand _redoCommand;

    static CustomCommand()
    {

        _saveCommand = new RoutedUICommand("Save", "SaveCommand", typeof(CustomCommand));
        _loadCommand = new RoutedUICommand("Load", "LoadCommand", typeof(CustomCommand));
        _searchCommand = new RoutedUICommand("Search", "SearchCommand", typeof(CustomCommand));
        _deleteCommand = new RoutedUICommand("Delete", "DeleteCommand", typeof(CustomCommand));
        _updateCommand = new RoutedUICommand("Update", "UpdateCommand", typeof(CustomCommand));
        _addCommand = new RoutedUICommand("Add", "AddCommand", typeof(CustomCommand));
        _undoCommand = new RoutedUICommand("Undor", "UndoCommand", typeof(CustomCommand));
        _redoCommand = new RoutedUICommand("Redor", "RedoCommand", typeof(CustomCommand));

    }

    public static RoutedUICommand SaveCommand
    {
        get { return _saveCommand; }
    }

    public static RoutedUICommand LoadCommand
    {
        get { return _loadCommand; }
    }

    public static RoutedUICommand SearchCommand
    {
        get { return _searchCommand; }
    }

    public static RoutedUICommand DeleteCommand
    {
        get { return _deleteCommand; }
    }

    public static RoutedUICommand UpdateCommand
    {
        get { return _updateCommand; }
    }

    public static RoutedUICommand AddCommand
    {
        get { return _addCommand; }
    }
    public static RoutedUICommand UndoCommand
    {
        get { return _undoCommand; }
    }
    public static RoutedUICommand RedoCommand
    {
        get { return _redoCommand; }
    }
}