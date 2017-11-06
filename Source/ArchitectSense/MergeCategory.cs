using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ArchitectSense
{
    public class MergeCategories : Def
    {
        public string from;
        public string to;

        public override IEnumerable<string> ConfigErrors()
        {
            var errors = base.ConfigErrors().ToList();
            if (from == null)
                errors.Add("from cannot be null");
            if (to == null)
                errors.Add("to cannot be null");
            return errors;
        }

        public void Apply()
        {
            var fromCategory = DesignatorUtility.ResolveCategory(from);
            var toCategory = DesignatorUtility.ResolveCategory(to);
            Controller.Logger.Debug( "Merging {0} into {1}", fromCategory, toCategory);
            DesignatorUtility.MergeDesignationCategories(toCategory, fromCategory);
        }
    }
}
