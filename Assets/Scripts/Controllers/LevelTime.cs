using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : LevelCondition 
{
    float m_timeLimit;
    private float m_time;

    private GameManager m_mngr;

    public override void Setup(float value, Text txt, params object[] args)
    {
        base.Setup(value, txt, args);

        m_mngr = (GameManager)args[0];

        m_time = m_timeLimit = value;

        UpdateText();
    }

    public override void Reset() {
        m_time = m_timeLimit;
        UpdateText();
    }

    private void Update()
    {
        if (m_conditionCompleted) return;

        if (m_mngr.State != GameManager.eStateGame.GAME_STARTED) return;

        m_time -= Time.deltaTime;

        UpdateText();

        if (m_time <= -1f)
        {
            OnConditionComplete();
        }
    }

    protected override void UpdateText()
    {
        if (m_time < 0f) return;

        m_txt.text = $"TIME:\n{m_time:00}";
    }
}
