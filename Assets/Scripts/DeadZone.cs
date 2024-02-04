using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

// [RequireComponent(typeof(Collider2D))] 是 Unity 中的屬性（Attribute），用於向繼承自 MonoBehaviour 的腳本類型添加額外的組件需求。這個屬性確保在該腳本所附加的遊戲物體上，至少有一個指定的組件。在這個例子中，指定的組件是 Collider2D。

// 讓我更詳細地解釋這行代碼：

// [RequireComponent(typeof(Collider2D))]： 這是一個 C# 屬性，被方括號括起來。這個屬性告訴 Unity 編輯器，這個腳本需要在同一遊戲物體上自動添加一個 Collider2D 組件。這樣，如果你將這個腳本附加到一個遊戲物體上，Unity 將會自動添加一個 Collider2D 組件，而不需要手動進行添加。

// typeof(Collider2D)： typeof 是一個 C# 運算符，它返回一個 System.Type 物件，代表指定類型的類型信息。在這裡，typeof(Collider2D) 返回的是 Collider2D 這個類型的 System.Type。

// RequireComponent： 這個屬性是 Unity 提供的，用於描述腳本類型的要求組件。在這個情況下，要求同一遊戲物體上有一個 Collider2D 組件。

// 這樣做的好處是，你在編輯器中將這個腳本附加到一個遊戲物體上時，Unity 將自動添加所需的 Collider2D 組件，省去了手動添加的步驟，同時確保腳本所需的組件是存在的。這在確保腳本的正確運行上非常有用，特別是當腳本依賴特定的組件時。

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDepress>().Dead();
        }
    }
}
