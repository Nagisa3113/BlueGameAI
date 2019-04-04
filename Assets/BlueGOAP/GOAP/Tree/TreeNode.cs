
namespace BlueGOAP
{
    public class TreeNode<TAction>
    {
        private static int _id;
        public int ID { get; private set; }
        /// <summary>
        /// 默认无父节点，值为null
        /// </summary>
        public TreeNode<TAction> ParentNode { get; set; }

        public IActionHandler<TAction> ActionHandler { get; private set; }
        public IState CurrentState { get; set; }
        public IState GoalState { get; set; }

        public int Cost { get; set; }

        public TreeNode(IActionHandler<TAction> handler)
        {
            ID = _id++;
            ActionHandler = handler;
            Cost = 0;
            ParentNode = null;
        }
    }
}
