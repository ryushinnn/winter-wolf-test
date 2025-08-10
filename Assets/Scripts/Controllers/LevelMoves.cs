using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMoves : LevelCondition 
{
    int m_movesLimit;
    private int m_moves;

    private BoardController m_board;

    public override void Setup(float value, Text txt, params object[] args)
    {
        base.Setup(value, txt);

        m_moves = m_movesLimit = (int)value;

        m_board = (BoardController)args[0];

        m_board.OnMoveEvent += OnMove;

        UpdateText();
    }

    public override void Reset() {
        m_moves = m_movesLimit;
        UpdateText();
    }

    private void OnMove()
    {
        if (m_conditionCompleted) return;

        m_moves--;

        UpdateText();

        if(m_moves <= 0)
        {
            OnConditionComplete();
        }
    }

    protected override void UpdateText()
    {
        m_txt.text = $"MOVES:\n{m_moves}";
    }

    protected override void OnDestroy()
    {
        if (m_board != null) m_board.OnMoveEvent -= OnMove;

        base.OnDestroy();
    }
}
