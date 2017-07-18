using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silk{
	public interface ITagCommand {

	    void TagExecute();

	    void TagUndo();
	}
}
