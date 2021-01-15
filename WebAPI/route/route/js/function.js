function RestoreJsonNetReferences(g) {
	var ids = {};

	function getIds(s) {
		// we care naught about primitives
		if (s === null || typeof s !== "object") { return s; }

		var id = s['$id'];
		if (typeof id != "undefined") {
			delete s['$id'];

			// either return previously known object, or
			// remember this object linking for later
			if (ids[id]) {
				throw "Duplicate ID " + id + "found.";
			}
			ids[id] = s;
		}

		// then, recursively for each key/index, relink the sub-graph
		if (s.hasOwnProperty('length')) {
			// array or array-like; a different guard may be more appropriate
			for (var i = 0; i < s.length; i++) {
				getIds(s[i]);
			}
		} else {
			// other objects
			for (var p in s) {
				if (s.hasOwnProperty(p)) {
					getIds(s[p]);
				}
			}
		}
	}

	function relink(s) {
		// we care naught about primitives
		if (s === null || typeof s !== "object") { return s; }

		var id = s['$ref'];
		delete s['$ref'];

		// either return previously known object, or
		// remember this object linking for later
		if (typeof id != "undefined") {
			return ids[id];
		}

		// then, recursively for each key/index, relink the sub-graph
		if (s.hasOwnProperty('length')) {
			// array or array-like; a different guard may be more appropriate
			for (var i = 0; i < s.length; i++) {
				s[i] = relink(s[i]);
			}
		} else {
			// other objects
			for (var p in s) {
				if (s.hasOwnProperty(p)) {
					s[p] = relink(s[p]);
				}
			}
		}

		return s;
	}

	getIds(g);
	return relink(g);
}
