using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Reflection;

namespace ZeroSys.Manager.WPF.Taskbar
{
    /// <summary>
    /// JumplistManager
    /// </summary>
    public class JumplistManager
    {

        private JumpList jumpList;
        private Assembly assembly;
        private string myExecutablePath;

        /// <summary>
        /// Initialize JumplistManager
        /// </summary>
        /// <param name="assembly"></param>
        public JumplistManager(Assembly assembly)
        {
            this.assembly = assembly;
            myExecutablePath = this.assembly.Location;
        }

        /// <summary>
        /// Initialize the Windows Taskbar Programm Icon JumpList
        /// </summary>
        public void CreateJumpList(JumpListLink[] jumplistEntrys, string jumplistHeading)
        {

            //jumpList.ClearAllUserTasks();
            //JumpListItem i = new JumpListItem("");

            jumpList = JumpList.CreateJumpList();

            JumpListCustomCategory personalCategory = new JumpListCustomCategory(jumplistHeading);//Category Name

            foreach (JumpListLink jll in jumplistEntrys)
            {
                personalCategory.AddJumpListItems(jll);
            }

            jumpList.AddCustomCategories(personalCategory);

            refrehsJumpList();
        }

        /// <summary>
        /// Create JumplistItem
        /// </summary>
        /// <param name="displayText"></param>
        /// <param name="iconPath"></param>
        /// <param name="startArgument"></param>
        /// <returns></returns>
        public JumpListLink CreateJumpListItem(string displayText, string iconPath, string startArgument)
        {
            JumpListLink jumpListLink = new JumpListLink(myExecutablePath, displayText);
            jumpListLink.IconReference = new IconReference(iconPath, 0);
            jumpListLink.Arguments = startArgument;
            return jumpListLink;
        }

        /// <summary>
        /// Refresh the Windows Taskbar Programm Icon Jumplist
        /// </summary>
        public void refrehsJumpList()
        {
            try
            {
                if (jumpList != null)
                    jumpList.Refresh();
            }
            catch
            {

            }
            //JumpList.SetJumpList(Application.Current, jumpList);
        }

    }
}
