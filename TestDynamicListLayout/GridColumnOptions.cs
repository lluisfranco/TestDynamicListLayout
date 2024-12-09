namespace TestDynamicListLayout
{
    public class GridColumnOptions
    {
        public bool AutoCreateColumnsOnSetData { get; set; } = true;
        public Color ColumnHighlightColor { get; set; }
        public GridColumnOptionsBehaviors OptionsBehaviors { get; set; } = new GridColumnOptionsBehaviors();
    }

    public class GridColumnOptionsBehaviors
    {
        public string BehaviorColumnSystemResourceImageName { get; set; } = "Behaviors.Behavior";
        public string BehaviorColumnCustomResourceImageName { get; set; } = "Behaviors.BehaviorBlue";
        public BehaviorColumnHighlightEnum BehaviorColumnHighlightMode { get; set; } = BehaviorColumnHighlightEnum.Image;
        public bool ShowBehaviorDisplayFormat { get; set; } = true;
        public bool ShowBehaviorDescriptionOnTooltip { get; set; } = false;
        public IList<ColumnBehaviorInfo> BehaviorsList { get; set; }
    }

    public enum BehaviorColumnHighlightEnum
    {
        None, Image
    }

    public class ColumnBehaviorInfo
    {
        public int BehaviorId { get; set; }
        public string BehaviorName { get; set; }
        public string BehaviorDescription { get; set; }
        public string DisplayFormat { get; set; }
    }
}
