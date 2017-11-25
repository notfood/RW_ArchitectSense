﻿using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ArchitectSense
{
    public class RemoveCategory : Def
    {
        public string category;

        public override IEnumerable<string> ConfigErrors()
        {
            var errors = base.ConfigErrors().ToList();
            if (category == null)
                errors.Add("category cannot be null");
            return errors;
        }
        
        public void Apply()
        {
            var resolved = DesignatorUtility.ResolveCategory(category);
            Controller.Logger.Debug("Removing {0}", resolved );
            DesignatorUtility.RemoveDesignationCategory(resolved);
        }
    }
}