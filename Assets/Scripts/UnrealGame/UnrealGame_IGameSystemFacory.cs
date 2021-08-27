﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unreal.BaseClass;
/// <summary>
/// 暫時將IGameSystem的Delegate的宣告放在這裡
/// TODO:未來會把DelegateInitialize跟Initialize等等拆開
/// </summary>
namespace Unreal
{
    public partial class UnrealGame
    {

        List<IGameSystem> m_GameSystems = new List<IGameSystem>();

        public void AddGameSystem(IGameSystem gameSystem)
        {
            m_GameSystems.Add(gameSystem);
        }

        public void RemoveGameSystem(IGameSystem gameSystem)
        {
            if(m_GameSystems.Contains(gameSystem))
            {
                m_GameSystems.Remove(gameSystem);
            }
        }

        public void UpdateGameSystem() //TODO:未來為主要的Update
        {
            if(m_GameSystems.Count > 0)
            {
                for(int i = 0; i < m_GameSystems.Count; i++)
                {
                    m_GameSystems[i].Update();
                }
            }
        }

        public void SetSaveDataManagerDelegateInitialize()
        {
            m_SaveDataManager.m_DelegateInitialize = delegate ()
            {
                m_SaveDataManager.SetResources(m_Resources);
                m_SaveDataManager.SetShowDataCheckInfoUI(m_DataCheckInfoUI.ShowDataCheckInfoUI);
                m_SaveDataManager.SetHideDataCheckInfoUI(m_DataCheckInfoUI.HideDataCheckInfoUI);
                //m_SaveDataManager.SetIsCheck(m_DataCheckInfoUI.IsCheck);
                m_SaveDataManager.SetSaveDataIsNotFoundAlert(m_DataCheckInfoUI.ShowSaveDataIsNotFoundAlert);
                m_SaveDataManager.SetWantToLoadDavaAlert(m_DataCheckInfoUI.ShowWantToLoadDavaAlert);
            };
            m_SaveDataManager.Initialize();
        }

        public void SetSceneControllerDelegateInitialize()
        {
            m_SceneController.m_DelegateInitialize = delegate ()
            {
                m_SceneController.SetLoadingUI(CreateLoadingUI);
            };
            m_SceneController.Initialize();
        }

        public void SetDialgoueSystemDelegateInitialize()
        {
            m_DialogueSystem.m_DelegateInitialize = delegate ()
            {

            };
            m_DialogueSystem.Initialize();
        }
    }
}