using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;

    private Wallet _wallet;

    private void Start()
    {
        _wallet = new Wallet();

        _walletView.Initialize(_wallet);
    }
}
