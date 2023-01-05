SELECT b.name, b.Description, bf.name, bf.Description, bi.name, bp.name, im.name, im.ImageUrl, t.Tag
FROM Beitrags b
INNER JOIN beitragFaces bf ON bf.Id = b.beitragFaceId
INNER JOIN beitragInstas bi ON bi.Id = b.beitragInstaId
INNER JOIN beitragPintrs bp ON bp.Id = b.beitragPintrId
INNER JOIN Images im ON im.Id = bf.ImageId
INNER JOIN Tags t ON t.Id = b.Id
