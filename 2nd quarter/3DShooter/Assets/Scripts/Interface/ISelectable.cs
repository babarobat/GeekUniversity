namespace Game
{
    /// <summary>
    /// Определяет поведение обьекта при выборе и потере фокуса
    /// </summary>
    public interface ISelectable
    {
        /// <summary>
        /// информация о выбранном обьекте
        /// </summary>
        SelectableItemInfo Info { get; }
        /// <summary>
        /// Определяет поведение при выборе обькета
        /// </summary>
        void OnSelected();
        /// <summary>
        /// Определяет поведение при смене фокуса
        /// </summary>
        void OnSelectionChange();

    }
}
