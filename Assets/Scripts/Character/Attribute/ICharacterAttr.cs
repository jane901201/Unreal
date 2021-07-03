using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAttr
{
    protected int maxHP = 0;
    protected int nowHP = 0;
    protected float moveSpd = 1.0f;
    protected string attrName = "";

    protected IAttrStrategy attrStrategy = null;


}