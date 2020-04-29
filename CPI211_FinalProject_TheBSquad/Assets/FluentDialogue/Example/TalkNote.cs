using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class TalkNote : ConversationWithImage
{
    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, "It's a list. You don’t know whose it is, but it includes an item list such as groceries and gloves. Theres also some tasks listed on the back; most are crossed off except for 'check the generator'") *
                Pause(1) *
                Options(
                    Option("->") *
                        Hide() *
                        End()
                );
    }

}
