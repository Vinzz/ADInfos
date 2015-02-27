using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using ADInfosService;

namespace cmdlet
{

    [Cmdlet(VerbsCommon.Find, "ADInfos")]
    public class FindADInfosCommand : Cmdlet
    {
        private ADService service = new ADService();

        // Declare the parameters for the cmdlet.
        [Parameter(Mandatory = true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string name;

       /// <summary>
       /// Finds informations in the AD about a given name
       /// <remarks>
       /// Name
       /// FirstName
       /// Login
       /// Service
       /// </remarks>
       /// </summary>
        protected override void ProcessRecord()
        {
            foreach(UserInfo user in service.GetADInfos(name))
            {
                WriteObject(user);
            }
        }
    }
}
