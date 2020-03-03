using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ID_PREFIC = "Player ";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();
    
    public static void RegisterPlayer(string _netID, Player _player)
    {
        string _PlayerID = PLAYER_ID_PREFIC + _netID;
        players.Add(_PlayerID, _player);
        _player.transform.name = _PlayerID;
    }

    public static void UnRegisterPlayer (string _playerID)
    {
        players.Remove(_playerID);
    }

    public static Player GetPLayer(string _playerID)
    {
        return players[_playerID];
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(200, 200, 200, 500));
        GUILayout.BeginVertical();

        foreach (string _playerID in players.Keys)
        {
            GUILayout.Label(_playerID + "  -  " + players[_playerID].transform.name);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

}
