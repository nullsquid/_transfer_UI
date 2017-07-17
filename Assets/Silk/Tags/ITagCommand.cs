using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITagCommand {

    void TagExecute();

    void TagUndo();
}
