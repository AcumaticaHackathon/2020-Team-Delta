using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using PX.Objects;
using PX.Objects.SO;

namespace MSTeamsIntegration
{
    public class MSTeamsMaint: PXGraph<MSTeamsMaint, TeamsPlugin>
    {
        [PXViewName("TeamsPlugin")]
        public PXSelect<TeamsPlugin> TeamsPlugin;
    }
}
