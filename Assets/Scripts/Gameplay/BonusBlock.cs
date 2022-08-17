using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A bonus block
/// </summary>	
public class BonusBlock : Block
{
    #region Unity methods

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>	
    override protected void Start()
    {
        base.Start();

        Points = ConfigurationUtils.BonusBlockPoints;
    }

    #endregion
}
